using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	public int indexOfWepon;
	public int ammo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Inventory>().currentWeaponAmmo[indexOfWepon] += ammo;
			Destroy(gameObject);
		}
	}
}
