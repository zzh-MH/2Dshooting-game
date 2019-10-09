using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int initialhealth;
    public int health;

    public Enemy[] enemies;
    public float spawnOffset;

    private int halfhealth;
    private Animator anim;
    public GameObject EnemyDie;
    public int damage;

    public Slider healthBar;
    public GameObject TransportPoint;
    public void TakeDamage(int amount) {
        health -= amount;
        healthBar.value = health;
        if (health <= 0) {
            scorecounter.scorevalue += 2000;
            Instantiate(EnemyDie, transform.position, Quaternion.identity);
            Instantiate(TransportPoint, transform.position, transform.rotation);
            Destroy(this.gameObject);
            healthBar.gameObject.SetActive(false);
            
        }
        if (health <= halfhealth) {
            anim.SetTrigger("stage2");

        }
        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0) , transform.rotation);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            print("yes");
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        health = initialhealth;
        healthBar.gameObject.SetActive(false);
        healthBar.value = health;
        
        halfhealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
