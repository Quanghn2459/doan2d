using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AudioData
{
    public float volume1 = -20;
    public float volume2 = -20;

    public AudioData(AudioManager1 audio)
    {
        volume1 = audio.volume1;
        volume2 = audio.volume2;
    }
}
