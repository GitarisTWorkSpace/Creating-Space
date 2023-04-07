using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float bulletLife = 3f;
	[SerializeField] public float damage = 30f;

	private void Awake()
	{
		Destroy(gameObject, bulletLife);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Zombie")
		{
			collision.gameObject.GetComponent<Zombie>().healthPointZ -= damage;
		}
		Destroy(gameObject);
	}
}
