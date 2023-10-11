using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Mika
{
    [DisallowMultipleComponent]
    public sealed class SoundManager : MonoBehaviour
    {
        #region Singleton
        public static SoundManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        [SerializeField] private SoundChannel[] soundChannels;
        [SerializeField] private AudioMixer audioMixer;

        private void Start()
        {
            ReadSettings();
        }

        private void ReadSettings()
        {
            for (int i = 0; i < this.soundChannels.Length; i++)
            {
                ReadVolume(soundChannels[i].name);
            }
            if (GetMasterVolume() > 0)
            {

            }
            if (!IsVolumeActive())
            {
                SwitchVolume();
            }
        }

        public void SwitchVolume()
        {
            SoundChannel masterChannel = FindChannel("Master");
            if (this.audioMixer.GetFloat(masterChannel.name, out float currentVolume))
            {
                if (currentVolume > -80f)
                {
                    masterChannel.volume = currentVolume;
                    this.audioMixer.SetFloat(masterChannel.name, -80f);
                    PlayerPrefs.SetInt("VolumeOn", 0);
                }
                else
                {
                    this.audioMixer.SetFloat(masterChannel.name, masterChannel.volume);
                    PlayerPrefs.SetInt("VolumeOn", 1);
                }
            }
        }

        public bool IsVolumeActive()
        {
            return !PlayerPrefs.HasKey("VolumeOn") || PlayerPrefs.GetInt("VolumeOn") == 1;
        }

        public float GetMasterVolume()
        {
            return GetVolume("Master");
        }

        public float GetMusicVolume()
        {
            return GetVolume("Music");
        }

        public float GetAmbientVolume()
        {
            return GetVolume("Ambient");
        }

        public float GetPlayerVolume()
        {
            return GetVolume("Player");
        }

        public float GetHostileVolume()
        {
            return GetVolume("Hostile");
        }

        public void SetMasterVolume(float value)
        {
            SaveVolume("Master", value);
        }

        public void SetMusicVolume(float value)
        {
            SaveVolume("Music", value);
        }

        public void SetAmbientVolume(float value)
        {
            SaveVolume("Ambient", value);
        }

        public void SetPlayerVolume(float value)
        {
            SaveVolume("Player", value);
        }

        public void SetHostileVolume(float value)
        {
            SaveVolume("Hostile", value);
        }

        private void SaveVolume(String name, float value)
        {
            this.audioMixer.SetFloat(name, value);
            PlayerPrefs.SetFloat($"Volume{name}", value);
        }

        private void ReadVolume(String name)
        {
            string key = $"Volume{name}";
            if (PlayerPrefs.HasKey(key))
            {
                float volume = Mathf.Clamp(PlayerPrefs.GetFloat(key), -80f, 20f);
                audioMixer.SetFloat(name, volume);
            }
            else
            {
                this.audioMixer.GetFloat(name, out float volume);
                PlayerPrefs.SetFloat(key, volume);
            }
        }

        private float GetVolume(String name)
        {
            this.audioMixer.GetFloat(name, out float volume);
            return volume;
        }

        private SoundChannel FindChannel(string channelName)
        {
            return this.soundChannels.Where(c => c.name.Equals(channelName)).First();
        }
    }

    [Serializable]
    public struct SoundChannel
    {
        public string name;
        public float volume;
        public AudioMixerGroup audioMixerGroup;
    }
}
