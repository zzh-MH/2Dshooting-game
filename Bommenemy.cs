using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bommenemy : Enemy
{
    public float stopDistance;
    private Animator anim;
    public float countdown = 2f;
  
    public float attackTime;
    public float attackSpeed;
    public GameObject enemyToSummon;
    public GameObject soudObject;
    public GameObject boomprefabs;
    public bool isboom = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (isboom == false)
            {
                if (Vector2.Distance(transform.position, player.position) > stopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                }
                else if (Vector2.Distance(transform.position, player.position) <= stopDistance)
                {
                    isboom = true;
                }
            }
            else if (isboom == true) {
                transform.position = Vector2.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
                anim.SetTrigger("boom");
                countdown -= Time.deltaTime;
                if (countdown <= 0)
                {
                    Instantiate(soudObject, transform.position, transform.rotation);
                    Instantiate(boomprefabs, transform.position, Quaternion.identity);

                    Instantiate(enemyToSummon, transform.position, transform.rotation);
                    Instantiate(enemyToSummon, transform.position, transform.rotation);


                    Destroy(gameObject);

                }
            }
           else  if (health <= 15)
            {
                scorecounter.scorevalue += 300;
                transform.position = Vector2.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
                anim.SetTrigger("boom");
                countdown -= Time.deltaTime;
                if (countdown <= 0)
                {
                    Instantiate(soudObject, transform.position, transform.rotation);
                    Instantiate(boomprefabs, transform.position, Quaternion.identity);
                   
                        Instantiate(enemyToSummon, transform.position, transform.rotation);
                      Instantiate(enemyToSummon, transform.position, transform.rotation);
                    
                    
                    Destroy(gameObject);

                }
                

            }
            else if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
               
                
            }
            



        }
    }
   
    
       
    
}   
