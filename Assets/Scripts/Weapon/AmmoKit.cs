using UnityEngine;

public class AmmoKit : MonoBehaviour
{
	public int typeWeapon;
	public int ammo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			
			Destroy(gameObject);
		}
	}
}
