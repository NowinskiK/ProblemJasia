using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ProblemJasiaRetro
{

    public class Music
    {

        public WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public string Title = "";
        private string tempDir = Path.GetTempPath();

        public Music()
        {
            string[] tracks = Properties.Resources.tracks.Split('\r', '\n');

            foreach (string track in tracks)
            {
                if (track.Length > 0)
                {
                    string file = tempDir + track + ".mp3";
                    System.IO.File.WriteAllBytes(file, GetTrackBytes(track));
                    Console.WriteLine(file);
                }
            }
        }

        public void Play(string suffix, bool isLoop = false)
        {
            Title = suffix;
            string file = tempDir + "pj_{suffix}.mp3";
            file = file.Replace("{suffix}", suffix);
            player.controls.stop();
            player.close();
            player.URL = file;
            player.settings.setMode("Loop", isLoop);
            player.controls.play();
        }

        public void Pause()
        {
            player.controls.pause();
        }

        public void Continue()
        {
            player.controls.play();
        }

        private byte[] GetTrackBytes(string name)
        {
            object obj = Properties.Resources.ResourceManager.GetObject(name, Properties.Resources.Culture);
            return ((byte[])(obj));
        }


    }
}
