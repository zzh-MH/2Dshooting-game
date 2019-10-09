using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public weapon weaponToEquip;
    public GameObject PickupWeaponSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            scorecounter.scorevalue += 200;
            Instantiate(PickupWeaponSound, transform.position, transform.rotation);
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);

            Destroy(gameObject);
        }
    }
   
}
