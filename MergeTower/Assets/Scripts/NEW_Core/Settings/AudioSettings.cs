using Core.StorageSystem;
using System;
using UnityEngine;

namespace Core
{
    public class AudioSettings : ISettings
    {
        protected const string KEY_AUDIO_SETTINGS = "AUDIO_SETTINGS";

        public event Action VolumeMusicChange;
        public event Action VolumeSoundsChange;

        private Storage gameSettingsStorage;
        private AudioSettingsData audioData;

        public float VolumeMusic
        {
            get => audioData.VolumeMusic;
            set
            {
                audioData.VolumeMusic = Mathf.Clamp(value, 0f, 1f);
                VolumeMusicChange?.Invoke();
            }
        }

        public float VolumeSounds
        {
            get => audioData.VolumeSounds;
            set
            {
                audioData.VolumeSounds = Mathf.Clamp(value, 0f, 1f);
                VolumeSoundsChange?.Invoke();
            }
        }

        public AudioSettings(Storage gameSettingsStorage)
        {
            this.gameSettingsStorage = gameSettingsStorage;

            var audioDataByDefault = new AudioSettingsData();
            var loadedData = gameSettingsStorage.Get(KEY_AUDIO_SETTINGS, audioDataByDefault);
            audioData = loadedData;
        }

        public void Save()
        {
            gameSettingsStorage.Set(KEY_AUDIO_SETTINGS, audioData);
            gameSettingsStorage.Save();
        }
    }
}
