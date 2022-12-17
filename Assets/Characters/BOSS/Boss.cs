using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Enemes enemy;
    public GameObject gplayer;
    public Rigidbody2D pr;
    private NavMeshAgent agent;
    [SerializeField] Transform player;
    public bool isFlipped = false;
    public int attackDmg = 20;
    public float attackRange = 1f;
    //public Vector3 attackOffset;
    public LayerMask attackMask;
    public Transform Right;
    public Transform Left;
    public float circleRange;
    public Rigidbody2D rb;
    public float speed = 2.5f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Enemes stats = enemy.GetComponent<Enemes>();
        if (stats.currentHealth > 0)
        {
            //Vector2 target = new Vector2(player.position.x, player.position.y);
            //Vector2 newPos = Vector2.MoveTowards(rb.position, target, 10 * Time.fixedDeltaTime);
            //rb.MovePosition(newPos);
            //var a = new Vector2(player.position.x, player.position.y);
            agent.SetDestination(player.position);
            if (Vector2.Distance(player.position, rb.position) <= circleRange*3)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack()
    {
        Enemes stats = enemy.GetComponent<Enemes>();
        if (stats.currentHealth > 0)
        {
            if (isFlipped)
            {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Left.position, attackRange, attackMask);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<PlayerController>().TakeDamage(attackDmg);
                    //attacksound.Play();
                    KnockBack(gplayer);
                }
            }
            else
            {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Left.position, attackRange, attackMask);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<PlayerController>().TakeDamage(attackDmg);
                    KnockBack(gplayer);
                }
            }
        }
    }

    public void KnockBack(GameObject other)
    {
        //PlayerController stats1 = gplayer.GetComponent<PlayerController>();
        Vector2 kb = (other.transform.position - transform.position).normalized; //direction
        //Vector2 kb1 = (transform.position - other.transform.position).normalized;
        //// pr.AddForce(kb * 1000, ForceMode2D.Force);
        pr.AddForce(kb * 3000, ForceMode2D.Force); //rigid boss
    }

    void OnDrawGizmosSelected()
    {
        if (Right == null)
            return;
        Gizmos.DrawWireSphere(Right.position, circleRange);
        if (Left == null)
            return;
        Gizmos.DrawWireSphere(Left.position, circleRange);
    }
}
