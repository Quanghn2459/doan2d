using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy1 : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            if (GameObject.FindGameObjectWithTag("GameMusic") != null)
            {
                var a = GameObject.FindGameObjectWithTag("GameMusic");
                Destroy(a);
            }
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (GameObject.FindGameObjectWithTag("GameMusic1") != null)
            {
                var a = GameObject.FindGameObjectWithTag("GameMusic1");
                Destroy(a);
            }
            //if (GameObject.FindGameObjectWithTag("Brightness") != null)
            //{
            //    var a = GameObject.FindGameObjectWithTag("Brightness");
            //    Destroy(a);
            //}
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (GameObject.FindGameObjectWithTag("GameMusic2") != null)
            {
                var a = GameObject.FindGameObjectWithTag("GameMusic2");
                Destroy(a);
            }
        }
    }

}
