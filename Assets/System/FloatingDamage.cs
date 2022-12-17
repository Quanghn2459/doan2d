using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Layer 1:
//          -Player: Layer1 ord 2
//          _Tilemap grid0 : (grid 0.5) ground layer 1 ord 0, grass layer 1 ord 1, wall layer 1 ord 1
//          _Things:
//                  + Most: Layer 1 ord 2
//                  + Top gate: Layer 2 ord 1
public class FloatingDamage : MonoBehaviour
{
    //public GameObject gameObject;


    public void DisableText()
    {
        this.gameObject.SetActive(false);
    }
}
