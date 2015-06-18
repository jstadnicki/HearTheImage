using System.IO;
using System.Media;
using NAudio.Wave;
using Un4seen.Bass;

namespace HearTheImage
{
    public interface IBassPlayer
    {
        void PlayStream(Mp3FileReader streamid);
    }

    class BassPlayer : IBassPlayer
    {
        public void PlayStream(Mp3FileReader streamid)
        {
            var waveOutDevice = new WaveOut();
            waveOutDevice.Init(streamid);
            waveOutDevice.Play();
        }
    }
}