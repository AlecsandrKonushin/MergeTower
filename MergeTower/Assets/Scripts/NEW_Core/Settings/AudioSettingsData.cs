using System;

namespace Core
{
    [Serializable]
    public class AudioSettingsData
    {
        private const float MAX_VOLUME = 1f;
        private const float MIN_VOLUME = 0f;

        public float VolumeMusic;
        public float VolumeSounds;

        public AudioSettingsData()
        {
            VolumeMusic = MAX_VOLUME;
            VolumeSounds = MAX_VOLUME;
        }
    }
}
