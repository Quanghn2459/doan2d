using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager1 : MonoBehaviour
{
    public AudioMixer mixer;

    public GameObject panel;

    public Slider volsli;

    public Slider sfxsli;

    public float volume1 = -20;

    public float volume2 = -20;

    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SaveLoad.SaveAudio(this);
        }
        LoadAudio();    
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("ThemeVolume", volume);
        volume1 = volume;
        SaveAudio();
    }

    public void SetVolume1(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
        volume2 = volume;
        SaveAudio();
    }

    public void OnSetting()
    {
        panel.SetActive(true);
    }

    public void OffSetting()
    {
        panel.SetActive(false);
    }

    public void SaveAudio()
    {
        SaveLoad.SaveAudio(this);
    }

    public void LoadAudio()
    {
        AudioData data = SaveLoad.LoadAudio();
        volume1 = data.volume1;
        volume2 = data.volume2;
        volsli.value = volume1;
        sfxsli.value = volume2;
    }

    public void Setdefault()
    {
        volume1 = -20f;
        volume2 = -20f;
    }
}
