using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject panel_setting;
    public AudioSource audioSource;
    public AudioMixer mainmixer;
    private float musicVolume = 1f;

    void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        audioSource.volume = musicVolume; 

    }

    public void updateVolume(float volume)
    { 
        musicVolume = volume;
    }

    public void updateVolumemain(float volume)
    { 
        mainmixer.SetFloat("mainvolume",volume);
    }

    public void OnSetting()
    {
        panel_setting.SetActive(true);
    }

    public void OffSetting()
    {
        panel_setting.SetActive(false);
    }

}
