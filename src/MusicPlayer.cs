using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemJasiaRetro
{

    public class Music
    {

        public WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public string Title = "";

        public Music()
        {
        }

        public void Play(string suffix, bool isLoop = false)
        {
            Title = suffix;
            string file = @"d:\GitHub\NowinskiK\ProblemJasia\music\pj_{suffix}.mp3";
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


    }
}
