using UnityEngine;

public class MediKit : MonoBehaviour
{
	public float healthPoint;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Health>().GetHealing(healthPoint);
			Destroy(gameObject);
		}
	}
}
