using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public List<SpriteRenderer> runes;
    public float lerpSpeed;
    public GameObject door1;
    public GameObject door2;

    private Color curColor;
    private Color targetColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 1);
        door1.SetActive(false);
        door2.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        foreach (var r in runes)
        {
            r.color = curColor;
        }
    }
}

