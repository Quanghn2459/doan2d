using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffEffect : MonoBehaviour
{

    public void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buffdamage1(Collider2D player)
    {
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.LoadPlayer();
        stats.attackDamage += 10;
        stats.SavePlayer();
    }

    public void buffdamage2(Collider2D player)
    {
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.LoadPlayer();
        stats.attackDamage += 20;
        stats.SavePlayer();
    }

    public void buffhp1(Collider2D player)
    {
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.LoadPlayer();
        stats.maxHealth += 100;
        stats.SavePlayer();
    }

    public void buffhp2(Collider2D player)
    {
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.LoadPlayer();
        stats.maxHealth += 200;
        stats.SavePlayer();
    }

    public void buffmana(Collider2D player)
    {
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.LoadPlayer();
        stats.maxMana += 200;
        stats.SavePlayer();
    }

    public void buffatkspd(Collider2D player)
    {
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.LoadPlayer();
        stats.attackRate += 2f;
        stats.SavePlayer();
    }

}
