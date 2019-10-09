using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPick : MonoBehaviour
{
    Player playerScript;
    public int healAmount;

    public GameObject PickupSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            playerScript.Heal(healAmount);
            scorecounter.scorevalue += 50;
            Destroy(gameObject);
            Instantiate(PickupSound, transform.position, Quaternion.identity);
        }
    }



    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
