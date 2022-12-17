using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMove : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 target = new Vector2(player.position.x, player.position.y);
        agent.SetDestination(player.position);
    }
}
