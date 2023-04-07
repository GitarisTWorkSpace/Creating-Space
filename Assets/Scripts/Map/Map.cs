using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	public GameObject ammo;
	public GameObject player;
	public GameObject healing;

	[SerializeField] public GameObject[] healthSpawners;
	[SerializeField] public GameObject[] ammoSpawners;

	public int[] ammoInWeapon;
	public bool waveIsDone = false;

	private void Start()
	{
		ammoInWeapon = player.GetComponent<Inventory>().maxCurrentAmmoInWeapon;
	}

	private void SpawnAmmo(int indexWeapon, int ammonaiton, GameObject spawner)
	{
		int ammoInCase = ammonaiton * ammoInWeapon[indexWeapon];
		GameObject ammoCase = ammo;
		ammoCase.GetComponent<Ammo>().indexOfWepon = indexWeapon;
		ammoCase.GetComponent<Ammo>().ammo = ammoInCase;
		Instantiate(ammoCase, spawner.transform.position, Quaternion.identity);
	}

	private void SpawnHealing(float health, GameObject spawner)
	{
		GameObject healthCase = healing;
		healthCase.GetComponent<Heal>().healthPoint = health;
		Instantiate(healthCase, spawner.transform.position, Quaternion.identity);
	}

    private void Update()
    {
        if (waveIsDone)
        {
			for (int i = 0; i < ammoSpawners.Length; i++)
            {
				SpawnAmmo(Random.Range(1, 3), Random.Range(1, 5), ammoSpawners[i]);
				SpawnHealing(Random.Range(1, 5) * 10, healthSpawners[i]);
			}
			waveIsDone = false;
        }
    }
}
