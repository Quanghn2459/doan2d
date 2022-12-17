using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_move : MonoBehaviour
{
    public float coinspeed = 4f;
    public GameObject coins;
    public GameObject toCoins;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        transform.position += Vector3.Lerp(transform.position, toCoins.transform.position, coinspeed * Time.deltaTime);
    }

    // Update is called once per frame
}
