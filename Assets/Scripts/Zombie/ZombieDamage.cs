using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    private float damage;
    private float fireRate;
    private float nextDamage;

    private void OnTriggerStay(Collider other)
    {
        damage = transform.parent.gameObject.GetComponent<Zombie>().damage;
        fireRate = transform.parent.gameObject.GetComponent<Zombie>().fireRate;

        if (other.gameObject.tag == "Player")
        {
            if(Time.time > nextDamage)
            {
                nextDamage = Time.time + fireRate;
                other.GetComponent<Health>().GetDamage(damage);
            }
        }
    }
}
