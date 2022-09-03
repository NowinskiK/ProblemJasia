using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace ProblemJasiaRetro
{
    public partial class frmGame : Form
    {
        Point BOARD_LOCATION = new Point(703, 95);
        Point HINT_LOCATION = new Point(464, 495);
        int BOMB_TIMEOUT_MS = 2000;
        const int ALL_BOXES = 24;

        int _x = 0;  //0-3 & -1
        int _y = 0;  //0-4 & -1
        Point _startLoc;
        bool _CanPlay = false;
        Control[] boxes = new Control[ALL_BOXES];
        List<Point> boxLoc = new List<Point>();
        int _TimeRemaining = 60 * 5;
        Music p = new Music();
        int _level = 1;
        bool HiRes = false;
        int _nextElement = 0;
        int _bombFuse = 0;
        Random rnd = new Random();
        string _WaitContext = "";
        bool _PauseActive = false;

        public frmGame()
        {
            InitializeComponent();
            for (int i = 0; i < ALL_BOXES; i++) { boxLoc.Add(new Point(-1, -1)); }
            p.player.PlayStateChange += Player_PlayStateChange;
            lblDebug.Visible = Program.isDebugging();
            this.Text += " (version: " + Program.GetAppVersion() + ")";
        }

        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == 8 && p.Title.StartsWith("level_"))
            {
                StartGame();
            }
            if (NewState == 8 && p.Title == "failed")
            {
                this.Close();
            }
        }

        private void frmGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CanPlay)
            {
                if (_x == -1)
                {
                    if (e.KeyData == Keys.Space) { PullElement(); }
                    if (e.Shift) { PullElement(); e.Handled = true; }
                }
                else
                {
                    if (e.KeyData == (Keys.Down | Keys.Shift)) { PushElement(_x, _y, 0, 1); }
                    if (e.KeyData == (Keys.Up | Keys.Shift)) { PushElement(_x, _y, 0, -1); }
                    if (e.KeyData == (Keys.Left | Keys.Shift)) { PushElement(_x, _y, -1, 0); }
                    if (e.KeyData == (Keys.Right | Keys.Shift)) { PushElement(_x, _y, 1, 0); }
                }
                if (e.KeyData == Keys.Down) { GoDown(); }
                if (e.KeyData == Keys.Up) { GoUp(); }
                if (e.KeyData == Keys.Left) { GoLeft(); }
                if (e.KeyData == Keys.Right) { GoRight(); }

                if (e.KeyData == (Keys.H | Keys.Control)) { HiRes = !HiRes; ReloadBoxes(false); }

                if (Program.isDebugging())
                {
                    if (e.KeyData == Keys.W) { WinLevel(); }
                    if (e.KeyData == Keys.F) { GameOver("User request"); }
                    if (e.KeyData == Keys.B) { _nextElement = 20; }
                    if (e.KeyData == Keys.H) { _nextElement = 21; }
                    if (e.KeyData == Keys.J) { _nextElement = 22; }
                    if (e.KeyData == Keys.M) { _nextElement = 23; }
                    if (e.KeyData == Keys.F12) { _level = 11; WinLevel(); }
                }
            }
            if (e.KeyData == Keys.Space) { GamePause(); }
        }

        private void GamePause()
        {
            _PauseActive = !_PauseActive;
            CanPlay = !_PauseActive;
            if (_PauseActive) 
            { 
                p.Pause(); 
            }
            else
            {
                p.Continue();
            }
        }

        private void WinLevel(int wait = 0)
        {
            CanPlay = false;
            bombTimer.Stop();
            p.Play("next");
            if (wait > 0) { Thread.Sleep(wait); }
            ShowFullPicture();
            ShowMessage(GetCompleteLevelMsg(_level), "NextLevel");
            _level++;
        }

        private void GameOver(string reason)
        {
            CanPlay = false;
            p.Play("failed");
            ShowMessage(GameOverMessage, "");
        }


        private void PushElement(int x, int y, int xDir, int yDir)
        {
            int MinAllowX = -1;
            if (IsBoxLocked || y > 0) { MinAllowX = 0; }
            int newX = x + xDir;
            int newY = y + yDir;
            if (newX < MinAllowX || newX > 3) return;
            if (newY < 0 || newY > 4) return;

            if (IsLocationFree(newX, newY))
            {
                int box = WhatIsInLocation(x, y);     //Selected box
                if (box >= 0)
                {
                    SetBoxLocation(box, newX, newY);
                    PushElement(newX, newY, xDir, yDir);
                }
            }
            RefreshSelector();
            CheckCorrectElementCount();
        }

        private void PullElement()
        {
            string boxTag = "";
            if (_x == -1 && _y == 0 && IsLocationFree(0, 0))
            {
                int box = RandomFromBox();
                boxTag = boxes[box].Tag.ToString();
                for (int i = 0; i < 4; i++)
                {
                    if (IsLocationFree(i, 0))
                    {
                        SetBoxLocation(box, i, 0);
                        IsBoxLocked = false;
                    }
                    else
                    {
                        break;
                    }
                }
                CheckCorrectElementCount();
                CheckSpecialBoxes(boxTag);
            }
        }

        private void CheckSpecialBoxes(string tag)
        {
            switch (tag)
            {
                case "bomb":
                    _bombFuse = BOMB_TIMEOUT_MS;
                    bombTimer.Start();
                    break;
                case "jok":
                    WinLevel(1000);
                    break;
                case "hihi":
                    HiHi();
                    break;
                case "min":
                    TimeRemaining += 60;
                    break;
                default:
                    break;
            }
        }

        private void HiHi()
        {
            if (VisibleCount < 2) return;
            int a = RandomVisibleBox();
            int b = -1;
            do
            {
                b = RandomVisibleBox();
            } while (a == b);
            Point pa = boxLoc[a];
            Point pb = boxLoc[b];
            Thread.Sleep(150);
            SetBoxLocation(a, pb.X, pb.Y);
            SetBoxLocation(b, pa.X, pa.Y);
        }

        private void CheckCorrectElementCount()
        {
            int cnt = 0;
            for (int i = 0; i < 20; i++)
            {
                int expected_x = i % 4;
                int expected_y = i / 4;

                if (boxes[i].Visible == true && expected_x == boxLoc[i].X && expected_y == boxLoc[i].Y) 
                { 
                    cnt++; 
                }
            }
            if (cnt == 20) { WinLevel(); }
        }

        private bool IsLocationFree(int x, int y)
        {
            if (x == -1 && IsBoxLocked == false) return true;
            bool r = true;
            Point loc = new Point(x, y);
            for (int i = 0; i < ALL_BOXES; i++)
            {
                if (boxLoc[i] == loc) { r = false; }
            }
            return r;
        }
        private int WhatIsInLocation(int x, int y)
        {
            Point loc = new Point(x, y);
            for (int i = 0; i < ALL_BOXES; i++)
            {
                if (boxLoc[i] == loc) { return i; }
            }
            return -1;
        }


        private int RandomVisibleBox()
        {
            Random rnd = new Random();
            int i;
            do
            {
                i = rnd.Next(20);     // creates a number between 0 and 19
            } while (boxes[i].Visible == false);
            return i;
        }

        private int RandomFromBox()
        {
            if (_nextElement > 0)  //debug only
            {
                int r = _nextElement;
                _nextElement = 0;
                return r;
            }
            
            int i = rnd.Next(200);  // creates a number between 0 and 199
            if (i == 199) { return 22; }  //jok  1/200
            if (i >= 196) { return 21; }  //hihi 3/200
            if (i >= 193) { return 23; }  //1min 3/200
            //Everything else - pull normal piece, inc. bomb
            do
            {
                i = rnd.Next(21);     // creates a number between 0 and 20 (20=bomb)
            } while (boxes[i].Visible == true);
            return i;
        }
        private void SetBoxLocation(int box, int x, int y)
        {
            boxes[box].Location = new Point(BOARD_LOCATION.X + 128 * x, BOARD_LOCATION.Y + 128 * y);
            boxes[box].Visible = (x >= 0);
            boxLoc[box] = new Point(x, y);
            if (x < 0)
            {
                IsBoxLocked = true;
                if (boxes[box].Tag.ToString() == "bomb")
                {
                    bombTimer.Stop();
                }
            }
            RefreshSelector();
            this.Refresh();
            Thread.Sleep(10);
        }

        private void GoRight()
        {
            if (_x < 3)
            {
                _x++;
            }
            SetSelectorLocation();
        }
        private void GoLeft()
        {
            if (_x > 0 || _x == 0 && _y == 0)
            {
                _x--;
            }
            SetSelectorLocation();
        }
        private void GoDown()
        {
            if (_x >= 0 && _y < 4)
            {
                _y++;
            }
            SetSelectorLocation();
        }
        private void GoUp()
        {
            if (_y > 0)
            {
                _y--;
            }
            SetSelectorLocation();
        }
        private void SetSelectorLocation()
        {
            int offset = 0;
            if (_x == -1) { offset = -32; }
            Point p = new Point(_startLoc.X + 128 * _x + offset, _startLoc.Y + 128 * _y);
            selector.Location = p;
            RefreshSelector();
            SetHintLocation();
        }

        private void RefreshSelector()
        {
            int box = WhatIsInLocation(_x, _y);     //Selected box
            if (_x >= 0 && box >= 0)
            {
                selector.BackgroundImage = ((PictureBox)boxes[box]).Image;
            }
            else if (_x == -1 && IsBoxLocked)
            {
                selector.BackgroundImage = picRedArrow.Image;
            }
            else
            {
                selector.BackgroundImage = null;
            }
        }

        private void SetHintLocation()
        {
            int LocationIndex = _y * 4 + _x;
            int box = WhatIsInLocation(_x, _y);
            if (box>=20) { box = -box; }
            if (box >= 0)
            {
                panel1.Location = new Point(HINT_LOCATION.X + (panel1.Width + 10) * (box % 4), HINT_LOCATION.Y + (panel1.Height + 4) * (box / 4));
            }
            panel1.Visible = (box >= 0 && _x >= 0);
        }

        private void ShowFullPicture()
        {
            ReloadBoxes(true);
            CreateSpecialBox(Properties.Resources.bomb, 20, "bomb");
            CreateSpecialBox(Properties.Resources.hihi, 21, "hihi");
            CreateSpecialBox(Properties.Resources.jok, 22, "jok");
            CreateSpecialBox(Properties.Resources._1min, 23, "min");
        }

        private void HideAllBoxes()
        {
            for (int i = 0; i < ALL_BOXES; i++) 
            { 
                boxes[i].Visible = false;
                Point hidden = new Point(-1, 0);
                boxLoc[i] = hidden;
            }
        }

        private void ReloadBoxes(bool setDefaultLocation)
        {
            string HR = HiRes ? "h" : "";
            Image img = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("img_" + LevelFormatted + HR, Properties.Resources.Culture);

            for (int i = 0; i < 20; i++)
            {
                ReloadBox(img, i, setDefaultLocation);
            }
        }

        private void ReloadBox(Image fullImg, int i, bool setDefaultLocation)
        {
            int x = i % 4;
            int y = i / 4;

            PictureBox box = boxes[i] as PictureBox;
            if (box is null)
            {
                box = new PictureBox();
                this.Controls.Add(box);
            }
            box.Size = new Size(128, 128);
            box.Tag = "";
            if (setDefaultLocation)
            {
                box.Location = new Point(BOARD_LOCATION.X + x * 128, BOARD_LOCATION.Y + y * 128);
                box.Visible = true;
                this.Controls.SetChildIndex(box, 1);
            }
            Rectangle destRect, srcRect;
            Bitmap targetBitmap = new Bitmap(128, 128);
            Bitmap sourceBitmap = new Bitmap(fullImg, fullImg.Width, fullImg.Height);

            Graphics g = Graphics.FromImage(targetBitmap);
            destRect = new Rectangle(0, 0, 128, 128);
            srcRect = new Rectangle(128 * x, 128 * y, 128, 128);
            g.DrawImage(sourceBitmap, destRect, srcRect, GraphicsUnit.Pixel);

            box.Image = targetBitmap;
            boxes[i] = box;
        }

        private void CreateSpecialBox(Image img, int i, string tag)
        {
            PictureBox box = boxes[i] as PictureBox;
            if (box is null)
            {
                box = new PictureBox();
                //box.Load(imgPath);
                box.Image = img;
                this.Controls.Add(box);
            }
            box.Size = new Size(128, 128);
            box.Visible = false;
            box.Tag = tag;
            this.Controls.SetChildIndex(box, 1);
            boxes[i] = box;
        }


        private void frmGame_Shown(object sender, EventArgs e)
        {
            _startLoc = selector.Location;
            _startLoc = BOARD_LOCATION;
            PresentNextLevel();
        }

        private void PresentNextLevel()
        {
            _x = -1;
            _y = 0;
            SetSelectorLocation();
            if (_level > 12)
            {
                GameCompleted(true);
            }
            else
            {
                TimeRemaining = LevelTime;
                ShowFullPicture();
                p.Play(LevelFormatted);
                ShowMessage(GetWelcomeLevelMsg(_level), "");
            }
            this.Focus();
        }

        private void GameCompleted(bool playMusic)
        {
            string msg = "Noo Noo Nooooo, powiedziała Małgosia. Masz u mnie dużego buziaka, Jasiu." +
                "          I w ten sposób Jasio zdobył serce Małgosi." +
                "          Szkoda, że brat Jasia zginął tak brutalnie...";
            ShowMessage(msg, "RepeatWinnerMsg");
            if (playMusic)
            {
                p.Play("win", true);
            }
        }

        private void ShowMessage(string msg, string waitContext)
        {
            lblScroll.Text = new string(' ', 40) + msg.ToUpper();
            lblScroll.Location = new Point(0, lblScroll.Location.Y);
            _WaitContext = waitContext;
        }

        private void StartGame()
        {
            ShowMessage("", "");
            HideAllBoxes();
            selector.BringToFront();
            Thread.Sleep(150);
            CanPlay = true;
            p.Play("ingame");
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_PauseActive)
            {
                TimeVisible = !TimeVisible;
                return;
            }
            if (!_CanPlay) { return; }
            //Workaround - the above did not start the music!
            if (p.player.status == "Ready" && p.Title == "ingame")
            {
                p.Play("ingame");
            }

            if (TimeRemaining > 0) { TimeRemaining--; }
            else
            {
                GameOver("time");
            }
        }

        private bool TimeVisible
        {
            get { return lblMinutes.Visible; }
            set
            {
                lblMinutes.Visible = value;
                lblSeconds.Visible = value;
            }
        }

        private bool CanPlay
        {
            get { return _CanPlay; }
            set
            {
                _CanPlay = value;
                timer1.Enabled = true;
                TimeVisible = _CanPlay;
            }
        }

        private int TimeRemaining
        {
            get { return _TimeRemaining; }
            set
            {
                _TimeRemaining = value;
                lblSeconds.Text = (_TimeRemaining % 60).ToString("00");
                lblMinutes.Text = (_TimeRemaining / 60).ToString();
            }
        }

        private string GetWelcomeLevelMsg(int level)
        {
            switch (level)
            {
                case 1: return "Połam joystick!";
                case 2: return "Tego nie ułożysz!";
                case 3: return "To za trudne dla Ciebie";
                case 4: return "Niemożliwe do ułożenia";
                case 5: return "Nieukładalne.";
                case 6: return "Tere fere kuku!!!";
                case 7: return "Nie bądź taki do przodu.";
                case 8: return "Bujać to my, a nie nam.";
                case 9: return "To już tu doszedłeś?";
                case 10: return "Dobry jesteś. Ciekawe, jak długo jeszcze?";
                case 11: return "Spoko. Zostało jeszcze 347 plakatów.";
                case 12: return "To już finał. Niemożliwe stało się faktem.";
                default:
                    return "";
            }
        }

        private string GetCompleteLevelMsg(int level)
        {
            switch (level)
            {
                case 1: return "To był oczywiście Sylwek Stallone (i jego układy mięśni scallone).";
                case 2: return "Mało podobny, a jednak Louis de Funes. Kocham go.";
                case 3: return "Piękna Nasia Kinski. Zupełnie jak z gry pt. Problem Jasia.";
                case 4: return "Oto furiat Rutger Hauer.";
                case 5: return "Pewnie... to Woody Allen we własnej poważnej twarzy.";
                case 6: return "Oto ptaszek ciernistych krzewów: Rachel Ward. Nawet podobna.";
                case 7: return "Czarujący Patrick Swayze... jakie ma piękne nogi... (mówi Jaś).";
                case 8: return "Szalony Max Mel Gibson (Big Son).";
                case 9: return "Charlie Bronson. Skąd ja go znam? Chyba z telewizji.";
                case 10: return "Pucała..., tfu Pacuła. Aśka. Moja faworytka.";
                case 11: return "Oh. Ah. Eh. Marylin Monroe. Boska. Piękna. Namiętna...";
                case 12: return "He, He. Arnie Szwarcuś. Bardzo podobny do tego, co grał w Terminatorze.";
                default:
                    return "";
            }
        }

        private string LevelFormatted
        {
            get { return _level.ToString("level_00"); }
        }

        private string GameOverMessage
        {
            get {
                if (_level <= 4) return "Lepiej znajdź sobie inną dziewczynę, bo Małgosia już Cię nie kocha...";
                if (_level <= 8) return "Nie rozpieszczasz zbytnio Małgosi. Z pewnością nie będzie zadowolona.";
                return "No cóż, rzecze Małgosia, nie powiem, że się cieszę, ale zniknij mi z oczu!";
            }
        }

        private int LevelTime
        {
            get
            {
                if (_level <= 4) return 60 * 5;
                if (_level <= 8) return 60 * 4;
                return 60 * 3;
            }
        }

        private int VisibleCount
        {
            get
            {
                int cnt = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (boxes[i].Visible == true) { cnt++; }
                }
                return cnt;
            }
        }

        public bool IsBoxLocked
        {
            get
            { return picRedArrow.Visible; }
            set
            { picRedArrow.Visible = value; }
        }

        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            p.player.controls.stop();
            for (int i = 0; i < ALL_BOXES; i++)
            {
                boxes[i].Dispose();
            }
        }

        private void bombTimer_Tick(object sender, EventArgs e)
        {
            if (_PauseActive) return;
            _bombFuse -= bombTimer.Interval;
            lblDebug.Text = _bombFuse.ToString();
            selector.Refresh();
            if (_bombFuse == 0) { GameOver("bomb"); }
            if (_bombFuse <= -800) { SetBoxLocation(20, -1, 0); }
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            lblScroll.Location = new Point(lblScroll.Location.X - 10, lblScroll.Location.Y);
            if (lblScroll.Location.X + lblScroll.Width < 0) { 
                if (_WaitContext == "Close") { this.Close(); }
                if (_WaitContext == "NextLevel") { PresentNextLevel(); }
                if (_WaitContext == "RepeatWinnerMsg") { GameCompleted(false); }
            }

        }
    }
}
