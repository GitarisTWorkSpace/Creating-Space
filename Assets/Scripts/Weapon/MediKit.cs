using UnityEngine;

public class MediKit : MonoBehaviour
{
	public int indexMediKit;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            other.GetComponent<Inventory>().countMediKitIninvenory[indexMediKit] += 1;
			Destroy(gameObject);
		}
	}
}
