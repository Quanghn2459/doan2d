using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTrigger : MonoBehaviour
{
    public string layer;
    public string sortingLayer;
    public GameObject endtable2;
    public GameObject player;
    public GameObject Layer1;
    public GameObject Layer2;
    public GameObject Layer3;

    private void OnTriggerExit2D(Collider2D other)
    {
        //Object Trigger set layer default de nhan vat co the tuong tac khi o moi layer khac nhau
        other.gameObject.layer = LayerMask.NameToLayer(layer); //Collision
        other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer; //Sorting
        SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = sortingLayer;
        }
        if (layer == "Layer 2")
        {
            Layer2.SetActive(true);
        }
        if (layer == "Layer 3")
        {
            endtable2.SetActive(true);
            player.SetActive(false);
            //PlayerController stats = player.GetComponent<PlayerController>();
            //PlayerPrefs.SetInt("attackDamage", stats.attackDamage);
        }
    }
}
