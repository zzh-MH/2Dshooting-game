﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 导弹 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public GameObject soudObject;
    public int damage;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        Instantiate(soudObject, transform.position, transform.rotation);
    }
    void DestroyProjectile()
    {

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);

            DestroyProjectile();
        }

        if (collision.tag == "boss")
        {
            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }



    }
}
