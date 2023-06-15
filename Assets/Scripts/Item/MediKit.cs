using UnityEngine;

public class MediKit : MonoBehaviour
{
	public int indexMediKit;
	public int countMediKit = 1;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
      other.GetComponent<Inventory>().countMediKitIninvenory[indexMediKit] += countMediKit;
			Destroy(gameObject);
		}
	}
}
