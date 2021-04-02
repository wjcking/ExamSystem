using System.Media;
using System.IO;
using System.Windows.Forms;

namespace ExamSys.Util
{
    public class WavePlayer
    {
        public const string Play_Option = "playoption";
        public const string Play_Fav = "playfav";
        public const string Play_ShowKey = "playshowkey";
        public const string Play_Item = "playitem";
        public const string Play_Toggle = "playtoggle";

        private static readonly string Sound_Path = Application.StartupPath + "\\template\\sound\\{0}.wav";

        public static void Play(string waveFile)
        {
            if (!SysConfig.EnabledSound)
                return;


            string file = string.Format(Sound_Path, waveFile);

            if (!File.Exists(file))
                return;

            SoundPlayer soundPlayer = new SoundPlayer();
            FileStream stream = File.OpenRead(file);
            soundPlayer.Stream = stream;
            soundPlayer.Play();
            stream.Close();
        }
       

    }
}
