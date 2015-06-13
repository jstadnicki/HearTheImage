using Un4seen.Bass;

namespace HearTheImage
{
    public interface IBassPlayer
    {
        void PlayStream(int streamid);
    }

    class BassPlayer : IBassPlayer
    {
        public void PlayStream(int streamid)
        {
            Bass.BASS_ChannelPlay(streamid, false);
        }
    }
}