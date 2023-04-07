using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
	public float healthPoint;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Inventory>().healthPoint += healthPoint;
			Destroy(gameObject);
		}
	}
}
