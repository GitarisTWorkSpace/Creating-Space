using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[SerializeField] public GameObject Ammo; 
	[SerializeField] public GameObject Player; 
	[SerializeField] public GameObject MediKit; 

	[SerializeField] public GameObject[] MediKitSpawners; 
	[SerializeField] public GameObject[] AmmoSpawners; 

	[SerializeField]public int[] maxAmmoInWeapon; 

	public bool waveIsDone = false; 

	private void SpawnAmmo(int typeWeapon, int ammonaiton, GameObject spawner)
	{
		int ammoInCase = ammonaiton * maxAmmoInWeapon[typeWeapon]; 

		GameObject ammoCase = Ammo; 
		ammoCase.GetComponent<AmmoKit>().typeWeapon = typeWeapon; 
		ammoCase.GetComponent<AmmoKit>().ammo = ammoInCase; 
		
		Instantiate(ammoCase, spawner.transform.position, Quaternion.identity); 
	}

	private void SpawnHealing(int indexMediKit, GameObject spawner)
	{
		GameObject healthCase = MediKit;
		healthCase.GetComponent<MediKit>().indexMediKit = indexMediKit; 
		Instantiate(healthCase, spawner.transform.position, Quaternion.identity); 
	}

    private void FixedUpdate()
    {
        if (waveIsDone) // Если волна закончилась 
        {
			for (int i = 0; i < AmmoSpawners.Length; i++) // Спавним объекты
            {
				SpawnAmmo(Random.Range(1, 3), Random.Range(1, 4), AmmoSpawners[i]);
				SpawnHealing(Random.Range(0, 3), MediKitSpawners[i]);
			}
			waveIsDone = false;
        }
    }
}
