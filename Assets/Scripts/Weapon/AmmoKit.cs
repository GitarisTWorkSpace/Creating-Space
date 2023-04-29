using UnityEngine;

public class AmmoKit : MonoBehaviour
{
	public int typeWeapon;
	public int ammo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Inventory>().SetAmmoInWeapon(typeWeapon, ammo);
			Destroy(gameObject);
		}
	}
}
