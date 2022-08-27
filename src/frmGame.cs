using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace ProblemJasiaRetro
{
    public partial class frmGame : Form
    {
        Point BOARD_LOCATION = new Point(706, 94);
        Point HINT_LOCATION = new Point(464, 495);
        int BOMB_TIMEOUT_MS = 2000;

        int _x = 0;  //0-3 & -1
        int _y = 0;  //0-4 & -1
        Point _startLoc;
        bool _CanPlay = false;
        Control[] boxes = new Control[20+3];
        List<Point> boxLoc = new List<Point>();
        int _TimeRemaining = 60 * 5;
        Music p = new Music();
        int _level = 1;
        bool HiRes = true;
        int _nextElement = 0;
        int _bombFuse = 0;
        Random rnd = new Random();

        public frmGame()
        {
            InitializeComponent();
            for (int i = 0; i < 23; i++) { boxLoc.Add(new Point(-1, -1)); }
            //p.Player.PlaybackStopped += Player_PlaybackStopped;
            p.player.PlayStateChange += Player_PlayStateChange;
        }

        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == 8 && p.Title.StartsWith("level_"))
            {
                StartGame();
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
                    if (e.Shift) { PullElement(); }
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

                if (e.KeyData == Keys.W) { WinLevel(); }
                if (e.KeyData == Keys.F) { GameOver("User request"); }
                if (e.KeyData == Keys.B) { _nextElement = 20; }
                if (e.KeyData == Keys.H) { _nextElement = 21; }
                if (e.KeyData == Keys.J) { _nextElement = 22; }
                //if (e.KeyData == Keys.M) { StartGame(); }
            }


            if (e.KeyData == Keys.Q)
            {
                int idx = this.Controls.GetChildIndex(selector);
                this.Controls.SetChildIndex(selector, idx+1);
                this.Text = (idx + 1).ToString();
            }
                
        }

        private void WinLevel(int wait = 0)
        {
            CanPlay = false;
            p.Play("next");
            if (wait > 0) { Thread.Sleep(wait); }
            ShowFullPicture();
            //Napisy
            string msg = GetCompleteLevelMsg(_level);
            MessageBox.Show(msg, "Level completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _level++;
            PresentNextLevel();
        }

        private void GameOver(string reason)
        {
            CanPlay = false;
            p.Play("failed");
            //Napisy
            string msg = "Nie rozpieszczasz zbytnio Małgosi. Z pewnością nie będzie zadowolona.\r\n" + reason;
            MessageBox.Show(msg, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void PushElement(int x, int y, int xDir, int yDir)
        {
            int MinAllowX = -1;
            if (picRedArrow.Visible || y > 0) { MinAllowX = 0; }
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
            if (_x == -1 && _y == 0)
            {
                int box = RandomFromBox();
                boxTag = boxes[box].Tag.ToString();
                for (int i = 0; i < 4; i++)
                {
                    if (IsLocationFree(i, 0))
                    {
                        SetBoxLocation(box, i, 0);
                        picRedArrow.Visible = false;
                        CheckSpecialBoxes(boxTag);
                    }
                    else
                    {
                        break;
                    }
                }
                CheckCorrectElementCount();
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
            if (x == -1 && picRedArrow.Visible == false) return true;
            bool r = true;
            Point loc = new Point(x, y);
            for (int i = 0; i < 23; i++)
            {
                if (boxLoc[i] == loc) { r = false; }
            }
            return r;
        }
        private int WhatIsInLocation(int x, int y)
        {
            Point loc = new Point(x, y);
            for (int i = 0; i < 23; i++)
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
                picRedArrow.Visible = true;
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
            if (_x == -1) { offset = -40; }
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
                panel1.Location = new Point(HINT_LOCATION.X + (panel1.Width + 12) * (box % 4), HINT_LOCATION.Y + (panel1.Height + 4) * (box / 4));
            }
            panel1.Visible = (box >= 0 && _x >= 0);
        }

        private void ShowFullPicture()
        {
            string HR = HiRes ? "h" : "";
            string picFile = @"d:\GitHub\NowinskiK\ProblemJasia\images\img_"+ LevelFormatted + HR + ".png";
            Image img = Image.FromFile(picFile);

            for (int i = 0; i < 20; i++)
            {
                CreateBox(img, i);
            }
            //selector.BringToFront();
            CreateSpecialBox("d:\\GitHub\\NowinskiK\\ProblemJasia\\bomb.gif", 20, "bomb");
            CreateSpecialBox("d:\\GitHub\\NowinskiK\\ProblemJasia\\hihi.png", 21, "hihi");
            CreateSpecialBox("d:\\GitHub\\NowinskiK\\ProblemJasia\\jok.png", 22, "jok");
        }

        private void HideAllBoxes()
        {
            for (int i = 0; i < 23; i++) 
            { 
                boxes[i].Visible = false;
                Point hidden = new Point(-1, 0);
                boxLoc[i] = hidden;
            }
        }

        private void CreateBox(Image img, int i)
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
            box.Location = new Point(BOARD_LOCATION.X + x * 128, BOARD_LOCATION.Y + y * 128);
            box.Visible = true;
            box.Tag = "";
            this.Controls.SetChildIndex(box, 1);
            Rectangle destRect, srcRect;
            Bitmap targetBitmap = new Bitmap(128, 128);
            Bitmap sourceBitmap = new Bitmap(img, img.Width, img.Height);

            Graphics g = Graphics.FromImage(targetBitmap);
            destRect = new Rectangle(0, 0, 128, 128);
            srcRect = new Rectangle(128 * x, 128 * y, 128, 128);
            g.DrawImage(sourceBitmap, destRect, srcRect, GraphicsUnit.Pixel);
            // sourceBitmap.Dispose();

            box.Image = targetBitmap;
            boxes[i] = box;
        }

        private void CreateSpecialBox(String imgPath, int i, string tag)
        {
            PictureBox box = boxes[i] as PictureBox;
            if (box is null)
            {
                box = new PictureBox();
                box.Load(imgPath);
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
            TimeRemaining = 5 * 60;
            ShowFullPicture();
            p.Play(LevelFormatted);
            //this.Focus();
        }

        private void StartGame()
        {
            HideAllBoxes();
            selector.BringToFront();
            Thread.Sleep(150);
            CanPlay = true;
            p.Play("ingame");
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
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


        private bool CanPlay
        {
            get { return _CanPlay; }
            set
            {
                _CanPlay = value;
                timer1.Enabled = value;
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

        private string GetCompleteLevelMsg(int level)
        {
            switch (level)
            {
                case 1: return "To był oczywiście Sylwek Stallone (i jego układy mięśni scallone).";
                case 2: return "Mało podobny, a jednak Louis de Funes. Kocham go.";
                case 3: return "Piękna Nasia Kiński. Zupełnie jak z gry pt. Problem Jasia.";
                case 4: return "Oto furiat Rudger Hauer.";
                case 5: return "";
                case 6: return "";
                case 7: return "";
                case 8: return "";
                case 9: return "";
                case 10: return "";
                case 11: return "";
                case 12: return "";
                default:
                    return "";
            }
        }

        private string LevelFormatted
        {
            get { return _level.ToString("level_00"); }
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

        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            p.player.controls.stop();
        }

        private void bombTimer_Tick(object sender, EventArgs e)
        {
            _bombFuse -= bombTimer.Interval;
            lblDebug.Text = _bombFuse.ToString();
            if (_bombFuse <= 0) {
                bombTimer.Stop();
                GameOver("bomb");
            }
        }
    }
}
