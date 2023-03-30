using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int indexOfWepon;// test
    [SerializeField] private int ammo;

    public int SetWeapon(int indexWeapon) 
    {
        return indexWeapon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().currentWeaponAmmo[SetWeapon(indexOfWepon)] += ammo;
            Destroy(gameObject);
        }
    }
}
