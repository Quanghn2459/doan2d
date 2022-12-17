using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        GameObject[] brightObj = GameObject.FindGameObjectsWithTag("Brightness");
        if (musicObj.Length > 1 || brightObj.Length > 1) //Khong co dong nay nhac se bi chong len
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);     
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameObject[] musicObj1 = GameObject.FindGameObjectsWithTag("GameMusic2");
            if (musicObj.Length > 1) //Khong co dong nay nhac se bi chong len
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}
