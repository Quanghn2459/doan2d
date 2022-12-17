using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public TMP_Text scoretext;
    public int score = 0;
    PlayerController playerController;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        score = data.score;
        scoretext.text = score.ToString() + " COINS";
    }

    // Update is called once per frame
    public void AddCoin(int min, int max)
    {
        int random = Random.Range(min, max);
        score += random;
        scoretext.text = score.ToString() + " COINS";
    }
}
