using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Enemes : MonoBehaviour
{
    public HealthBarBehaviour healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public GameObject GameObject;
    public GameObject FloatingTextPrefab;
    public float coinspeed = 5f;
    public GameObject fireeffect;
    bool moveCoins = false;
    public GameObject hbar;
    public GameObject colli;
    public GameObject toCoins;
    public GameObject Lock1;
    public GameObject player;
    public GameObject endtable1;
    public GameObject wintable;

    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "FinalBoss")
        {
            maxHealth = 300;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth, maxHealth);
        }
        else
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    private void Update()
    {
        //coins.transform.position += Vector3.Lerp(transform.position, toCoins.transform.position, coinspeed * Time.deltaTime);
        if (moveCoins)
        {
            transform.position = Vector3.Lerp(transform.position, toCoins.transform.position, coinspeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int damage)
    {
        if (GameObject.tag == "FinalBoss")
        {
            BossTakeDamage(Randomdmg(damage-(damage / 5), damage + (damage / 5)));
        }
        else
        {
            int a = Randomdmg(damage - (damage / 5), damage + (damage / 5));
            currentHealth -= a;
            if (FloatingTextPrefab)
            {
                ShowFloatingText(a);
            }
            healthBar.SetHealth(currentHealth, maxHealth);
            animator.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                Instantiate(fireeffect, transform.position, Quaternion.identity);
                //Instantiate(coins, enemydie.position, Quaternion.identity);
                PlayerController stats = player.GetComponent<PlayerController>();
                if (this.GameObject.tag == "Boss1")
                {
                    Lock1.SetActive(false);
                    stats.TakeDamage(Randomdmg(10, 30));
                }
                else if (this.GameObject.tag == "EnemyLv1")
                {
                    stats.TakeDamage(Randomdmg(10, 30));
                    stats.count1 += 1;
                    if (stats.count1 == 4)  //hien thong bao khi danh chet 4 quai
                    {
                        endtable1.SetActive(true);
                        //PlayerPrefs.SetInt("attackDamage", stats.attackDamage);
                    }
                }
                else if (this.GameObject.tag == "Enemy1")
                {
                    stats.TakeDamage(Randomdmg(10, 30));
                }
                else if (this.GameObject.tag == "Enemy2")
                {
                    stats.TakeDamage(Randomdmg(10, 30));
                }
                hbar.SetActive(false);
                colli.SetActive(false);
                Defeat();
            }
        }
    }

    public void BossTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (FloatingTextPrefab)
        {
            ShowFloatingText(damage);
        }
        healthBar.SetHealth(currentHealth, maxHealth);     
        if (currentHealth <= 0)
        {
            animator.ResetTrigger("Attack");
            Instantiate(fireeffect, transform.position, Quaternion.identity);
            hbar.SetActive(false);
            Defeat();
        }
    }

    public void ShowFloatingText(int damage)
    { 
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = damage.ToString();
    }

    public void Defeat()
    {
        animator.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
    }

    public void DisableEnemy()
    {
        GameObject.SetActive(false);
        if (this.gameObject.tag == "EnemyLv1")
        {
            ScoreSystem.instance.AddCoin(1, 4);
        }
        else if (this.gameObject.tag == "Enemy1")
        {
            ScoreSystem.instance.AddCoin(1, 4);
        }
        else if (this.gameObject.tag == "Enemy2")
        {
            ScoreSystem.instance.AddCoin(5, 10);
        }
        else if (this.gameObject.tag == "Enemy3")
        {
            ScoreSystem.instance.AddCoin(11, 20);
        }
        else if (this.GameObject.tag == "Boss1")
        {
            ScoreSystem.instance.AddCoin(20, 30);
        }
        else if (this.GameObject.tag == "FinalBoss")
        {
            wintable.SetActive(true);
            ScoreSystem.instance.AddCoin(100, 200);
        }
    }

    public void Setmovecoin()
    {
        moveCoins = true;
    }

    public int Randomdmg(int min, int max)
    {
        int random = Random.Range(min, max);
        return random;
    }

    //public void Showdamage(string text)
    //{
    //    if (floatingdamage)
    //    {
    //        GameObject prefab = Instantiate(floatingdamage.gameObject, transform.position, Quaternion.identity);
    //        prefab.GetComponentInChildren<TextMeshPro>().text = text;
    //    }
    //}


}
