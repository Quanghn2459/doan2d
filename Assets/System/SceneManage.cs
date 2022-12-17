using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    int attackDamage;
    float maxHealth;
    float maxMana;
    float attackRate;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //var player = GetComponent<PlayerController>();
        //player.attackDamage = PlayerPrefs.GetInt("attackDamage", attackDamage);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SceneSignIn()
    {
        SceneManager.LoadScene("SignIn");
    }
    public void SceneRegister()
    {
        SceneManager.LoadScene("Register");
    }
    public void SceneIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void SceneBoost1()
    {   
        SceneManager.LoadScene("Boost1");
    }

    public void SceneBoost2()
    {
        
        SceneManager.LoadScene("Boost2");
        //PlayerPrefs.SetInt("attackDamage", player.attackDamage);
    }

    public void SceneLv2()
    {
        
        SceneManager.LoadScene("Level2");
        //PlayerPrefs.GetInt("attackDamage", player.attackDamage);
    }

    public void SceneLv3()
    {
        
        SceneManager.LoadScene("Level3");
        //PlayerPrefs.GetInt("attackDamage", player.attackDamage);
    }
}
