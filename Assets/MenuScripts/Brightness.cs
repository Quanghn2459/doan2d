using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Brightness : MonoBehaviour
{
    public Slider brightnessslider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    AutoExposure exposure;
    // Start is called before the first frame update
    void Start()
    {
        brightness.TryGetSettings(out exposure);
        AdjustBright(brightnessslider.value);
    }

    public void AdjustBright(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }
}