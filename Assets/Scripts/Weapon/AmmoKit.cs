using UnityEngine;

public class AmmoKit : MonoBehaviour
{
	public int indexOfWepon;
	public int ammo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
