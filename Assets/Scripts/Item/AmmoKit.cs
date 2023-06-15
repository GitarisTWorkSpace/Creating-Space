using UnityEngine;

public class AmmoKit : MonoBehaviour
{
	public int typeAmmonation;
	public int countAmmonation;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Inventory>().GetAmmonation(countAmmonation, typeAmmonation);
			Destroy(gameObject);
		}
	}
}
