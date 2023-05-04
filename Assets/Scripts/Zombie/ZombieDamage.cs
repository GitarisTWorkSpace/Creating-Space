using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    private float damage;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            damage = transform.parent.gameObject.GetComponent<Zombie>().damage;
            other.GetComponent<Health>().GetDamage(damage);
        }
    }
}
