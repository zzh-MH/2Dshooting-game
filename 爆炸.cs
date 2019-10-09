using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 爆炸 : MonoBehaviour
{
    public float expRadius = 10f;
    public int damage;
    private float countdown = 1f;
    private Enemy enemy;
    public LayerMask layerMask;
    public GameObject soudObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(soudObject, transform.position, transform.rotation);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boss") {
            collision.GetComponent<Boss>().TakeDamage(damage);

        }
        if (collision.gameObject.tag == "Enemy" ) {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, expRadius, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (Collider2D i in enemy) {
                Rigidbody2D rb = i.GetComponent<Rigidbody2D>();
                if (rb != null && rb.tag == "Enemy" || rb.tag == "boss") {
                    rb.GetComponent<Enemy>().TakeDamage(damage);

                }



            }

        }
    }
}
