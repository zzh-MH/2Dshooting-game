using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom特效 : MonoBehaviour
{
    private Player playerScript;
    public int damage;
    public float countdown = 1f;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
        }
        if (collision.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
        }

    }

}
