using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string BackgroundPrfef = "BackgroundPrfef";
    private static readonly string SoundEffectPrfef = "SoundEffectPrfef";
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPrfef);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPrfef);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectFloat;

        }
    }   
}
