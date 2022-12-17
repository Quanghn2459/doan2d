using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Slider healthBar;

    public Slider manaBar;

    public GameObject rebornpanel;

    public GameObject inpanel;

    public GameObject winpanel;

    public GameObject Player;

    public float moveSpeed = 3f;

    bool canMove = true;

    Vector2 movementInput;

    public Rigidbody2D rb;

    public GameObject boss;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public Transform attackPointRight;

    public Transform attackPointLeft;

    public Transform fireskillpoint;

    public float attackRange = 0.5f;

    public int attackDamage;

    public float attackRate = 2f;

    public float maxHealth = 200;

    public float currentHealth;

    public float maxMana = 100;

    public float currentMana;

    float nextAttackTime = 0f;

    double alphalevel = 0.4f;

    public LayerMask enemyLayers;

    public int count1 = 0;

    public int score = 0;

    ScoreSystem scoreSystem;

    public AudioSource atksound;

    public AudioSource movesound;

    public AudioSource fireskillsound;

    public GameObject fireskill;

    public void Awake()
    {
        LoadPlayer();
        //SavePlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        score = scoreSystem.score;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
        currentMana = maxMana;
        SetMana(currentMana, maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(currentHealth, maxHealth);
        SetMana(currentMana, maxMana);
        scoreSystem = FindObjectOfType<ScoreSystem>();
        score = scoreSystem.score;
        if (currentMana < maxMana)
        {
            ManaRestore(3);
        }
        //if (currentHealth <= 0)
        //{
        //    animator.SetTrigger("Death");
        //    GetComponent<Collider2D>().enabled = false;
        //}
        if (currentHealth > 0 && canMove)
        {
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");
            if (!movesound.isPlaying)
            {
                movesound.Play();
            }
            animator.SetFloat("movespeed", movementInput.sqrMagnitude);
            if (movementInput.x < 0)
            {  
                spriteRenderer.flipX = true;
                if (currentMana >= 20)
                {
                    LeftAttackLeft();
                }
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                if (currentMana >= 20)
                {
                    RightAttackRight();
                }
            }
            else if (movementInput.x == 0)
            {
                if (spriteRenderer.flipX == false)
                {
                    if (currentMana >= 20)
                    {
                        RightAttackRight();
                    }
                }
                if (spriteRenderer.flipX == true)
                {
                    if (currentMana >= 20)
                    {
                        LeftAttackLeft();
                    }
                }
                if (movementInput.y == 0)
                {
                    movesound.Stop();
                }
            }
        }
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    void AttackRight()
    {
        animator.SetTrigger("Attack");
        atksound.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemes>().TakeDamage(attackDamage);
        }
    }

    void AttackLeft()
    {
        animator.SetTrigger("Attack");
        atksound.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemes>().TakeDamage(attackDamage);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bush"))
        {
            var col = spriteRenderer.material.color;
            col.a = (float)alphalevel;
            spriteRenderer.material.color = col;
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bush"))
        {
            var col = spriteRenderer.material.color;
            col.a = 1;
            spriteRenderer.material.color = col;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPointRight == null)
            return;
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        if (attackPointLeft == null)
            return;
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }

    public void LockMove()
    {
        canMove = false;
        movementInput.x = 0;
        movementInput.y = 0;
        movesound.Stop();
    }

    public void UnlockMove()
    {
        canMove = true;
    }

    public void KnockBack()
    { 
        Vector2 kb = (transform.position - boss.transform.position).normalized;
        rb.AddForce(kb * 1000, ForceMode2D.Force);
    }

    public void SetHealth(float health, float maxhealth)
    {
        healthBar.gameObject.SetActive(true);
        healthBar.maxValue = maxhealth;
        healthBar.value = health;
    }

    public void SetMana(float mana, float maxmana)
    {
        manaBar.gameObject.SetActive(true);
        manaBar.maxValue = maxmana;
        manaBar.value = mana;
    }

    public void TakeDamage(float damage)
    {
        //Showdamage(damage.ToString());
        currentHealth -= damage;
        SetHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider2D>().enabled = false;
        }
    }


    public void ManaCost(int cost)
    {
        //Showdamage(damage.ToString());
        currentMana -= cost;
        SetMana(currentMana, maxMana);
    }

    public void ManaRestore(float mana)
    {
        //Showdamage(damage.ToString());
        currentMana += (mana / 600);
        SetMana(currentMana, maxMana);
    }

    public void RightAttackRight()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ManaCost(20);
                AttackRight();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (fireskill != null)
                {
                    animator.SetTrigger("Fireskill");
                    ManaCost(20);
                    Instantiate(fireskill, transform.position, Quaternion.identity);
                    fireskillsound.Play();
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(fireskillpoint.position, 1.7f, enemyLayers);
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        enemy.GetComponent<Enemes>().TakeDamage(attackDamage*2);
                    }
                }
            }
        }
    }

    public void LeftAttackLeft()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ManaCost(20);
                AttackLeft();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (fireskill != null)
                {
                    animator.SetTrigger("Fireskill");
                    ManaCost(20);
                    Instantiate(fireskill, transform.position, Quaternion.identity);
                    fireskillsound.Play();
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(fireskillpoint.position, 1.7f, enemyLayers);
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        enemy.GetComponent<Enemes>().TakeDamage(attackDamage*2);
                    }
                }
            }
        }
    }

    public void Death()
    {
        Player.SetActive(false);
        rebornpanel.SetActive(true);
    }
    public void Reborn()
    {
        Player.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            this.transform.position = new Vector3(-6, -3, 0);
        }
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
        currentMana = maxMana;
        SetMana(currentMana, maxMana);
        GetComponent<Collider2D>().enabled = true;
        rebornpanel.SetActive(false);
    }

    public void SavePlayer()
    {
        SaveLoad.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        attackDamage = data.attackDamage;
        maxHealth = data.maxHealth;
        maxMana = data.maxMana;
        attackRate = data.attackRate;
        score = data.score;
    }

    public void Setdefault()
    {
        attackDamage = 10;
        maxHealth = 100;
        currentHealth = 100;
        maxMana = 200;
        attackRate = 2f;
        score = 0;
        SaveLoad.SavePlayer(this);
        inpanel.SetActive(false);
    }

    public void Setdefault1()
    {
        attackDamage = 10;
        maxHealth = 100;
        currentHealth = 100;
        maxMana = 200;
        attackRate = 2f;
        score = 0;
        SaveLoad.SavePlayer(this);
        winpanel.SetActive(false);
    }
}