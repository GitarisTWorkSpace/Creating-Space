using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    private float damage;
    private float fireRate = 5f;
    private float nextDamage;

    private void OnTriggerStay(Collider other)
    {
        damage = transform.parent.gameObject.GetComponent<Zombie>().damage;

        if (other.gameObject.tag == "Player")
        {
            if(Time.time > nextDamage)
            {
                nextDamage = Time.time + fireRate;
                other.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}
