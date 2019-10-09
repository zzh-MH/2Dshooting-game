using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    [HideInInspector]
    public Transform player;
    public float speed;
    public int damage;
    public float timeBtweenAttack;
    public int healPickupChance;
    public GameObject healthPickup;

    public GameObject EnemyDie;

    public int pickupChance;
    public GameObject[] pickups;

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            scorecounter.scorevalue += 100;
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance) {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            int randHealth = Random.Range(0, 101);
            if (randHealth < healPickupChance) {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }
            if (this != null) {
                Instantiate(EnemyDie, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }

    }


    // Start is called before the first frame update
   public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
