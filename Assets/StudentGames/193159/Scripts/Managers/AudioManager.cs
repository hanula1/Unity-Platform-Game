using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace _193159
{
    public enum SoundType
    {
        BONUS,
        KEY,
        HEART,
        FALL,
        ENEMY_DEFEAT,
        ENEMY_SUCCESS,
        FINISH,
        CHECKPOINT,
        SUNGLASSES
    }

    class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] public AudioSource musicSource;
        [SerializeField] public AudioSource SFXSource;

        [Header("Audio Files")]
        [SerializeField] public AudioClip bonusSound;
        [SerializeField] public AudioClip keySound;
        [SerializeField] public AudioClip heartSound;
        [SerializeField] public AudioClip fallSound;
        [SerializeField] public AudioClip enemyDefeatSound;
        [SerializeField] public AudioClip enemySuccessSound;
        [SerializeField] public AudioClip finishSound;
        [SerializeField] public AudioClip checkpointSound;
        [SerializeField] public AudioClip sunglassesSound;

        [Header("Audio Sliders")]
        [SerializeField] public Slider masterSlider;
        [SerializeField] public Slider musicSlider;
        [SerializeField] public Slider SFXSlider;


        private static AudioManager instance;

        public static AudioManager Get()
        {
            return instance;
        }


        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            const float defaultVolume = 0.5f;
            masterSlider.value = PlayerPrefs.GetFloat("masterVolume", defaultVolume);
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume", defaultVolume);
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", defaultVolume);

            AudioListener.volume = masterSlider.value;
            musicSource.volume = musicSlider.value;
            SFXSource.volume = SFXSlider.value;
        }

        public void PlaySound(SoundType soundType)
        {
            AudioClip soundToPlay;
            switch (soundType)
            {
                case SoundType.BONUS:
                    soundToPlay = bonusSound;  
                    break;
                case SoundType.KEY:
                    soundToPlay = keySound;
                    break;
                case SoundType.HEART:
                    soundToPlay = heartSound;
                    break;
                case SoundType.FALL:
                    soundToPlay = fallSound;
                    break;
                case SoundType.ENEMY_DEFEAT:
                    soundToPlay = enemyDefeatSound;
                    break;
                case SoundType.ENEMY_SUCCESS:
                    soundToPlay = enemySuccessSound;
                    break;
                case SoundType.FINISH:
                    soundToPlay = finishSound;
                    break;
                case SoundType.CHECKPOINT:
                    soundToPlay = checkpointSound;
                    break;
                case SoundType.SUNGLASSES:
                    soundToPlay = sunglassesSound;
                    break;
                default:
                    throw new MissingComponentException();
            }
            SFXSource.PlayOneShot(soundToPlay, AudioListener.volume);
        }

        public void SetVolumeMaster(float vol)
        {
            AudioListener.volume = vol;
            PlayerPrefs.SetFloat("masterVolume", vol);
        }
        public void SetVolumeMusic(float vol)
        {
            musicSource.volume = vol;
            PlayerPrefs.SetFloat("musicVolume", vol);
        }
        public void SetVolumeSFX(float vol)
        {
            SFXSource.volume = vol;
            PlayerPrefs.SetFloat("SFXVolume", vol);
        }
    }
}
