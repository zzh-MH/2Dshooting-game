using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;

    private float attackTime;
    private Animator anim;
    public Transform shotpoint;
    public GameObject enemybullet;
    // Start is called before the first frame update
   public override  void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            if (Vector2.Distance(transform.position, player.position) > stopDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            if (Time.time >= attackTime) {
                attackTime = Time.time + timeBtweenAttack;
                anim.SetTrigger("attack");
            }
        }
    }
    public void RangedAttack() {
        Vector2 direction = player.position - shotpoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotpoint.rotation = rotation;
        Instantiate(enemybullet, shotpoint.position, shotpoint.rotation);
    }
}
