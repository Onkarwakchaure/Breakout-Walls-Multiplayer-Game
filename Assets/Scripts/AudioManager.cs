using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPrfef = "BackgroundPrfef";
    private static readonly string SoundEffectPrfef = "SoundEffectPrfef";

    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;

    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = .25f;
            soundEffectFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundPrfef, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPrfef, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, 1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPrfef);
            backgroundSlider.value = backgroundFloat;
            soundEffectFloat  = PlayerPrefs.GetFloat(SoundEffectPrfef);
            soundEffectSlider.value = soundEffectFloat;
        }

    }
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPrfef, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPrfef, soundEffectSlider.value);
    }

    void OnApplicationFocus(bool InFocus)
    {
        if (!InFocus )
        {
            SaveSoundSettings();
        }
    }
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectSlider.value;
        }
    }
}
