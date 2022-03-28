using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AudioSettings : MonoBehaviour
    {
        public event Action VolumeMusicChange;
        public event Action VolumeSoundsChange;

        private Storage storage;
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
    }
}
