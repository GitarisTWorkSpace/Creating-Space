using UnityEngine;

public class MediKit : MonoBehaviour
{
	public int indexMediKit;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//other.GetComponent<Health>().GetHealing(indexMediKit);
			Destroy(gameObject);
		}
	}
}
