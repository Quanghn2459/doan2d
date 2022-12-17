using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int attackDamage = 10;
    public float maxHealth = 200;
    public float maxMana = 100;
    public float attackRate = 1f;
    public int score = 0;

    public PlayerData(PlayerController player)
    {
        attackDamage = player.attackDamage;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        attackRate = player.attackRate;
        score = player.score;
    }
}
