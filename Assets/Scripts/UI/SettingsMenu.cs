using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    
    [Header("Audio")]
    [SerializeField] private AudioMixer mainAudioMixer;
    [SerializeField] private SettingsUI ui;

    [SerializeField] private float mainVolume = 1;


    public void SetMainAudioVolume(float volume)
    {
        mainVolume = volume;
        if (volume > 0)
        {
            mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            mainAudioMixer.SetFloat("MasterVolume", -80);
        }
    }

    public float GetMainAudioVolume()
    {
        float volume;
        mainAudioMixer.GetFloat("MasterVolume", out volume);
        return Mathf.Pow(10, volume / 20);
    }

}
