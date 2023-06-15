using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[SerializeField] public GameObject Ammo; 
	[SerializeField] public GameObject Player; 
	[SerializeField] public GameObject MediKit; 

	[SerializeField] public GameObject[] MediKitSpawners; 
	[SerializeField] public GameObject[] AmmoSpawners; 

	[SerializeField]public int[] maxAmmoInWeapon; 

	private void SpawnAmmo(int typeWeapon, int ammonaiton, GameObject spawner)
	{
		int ammoInCase = ammonaiton * maxAmmoInWeapon[typeWeapon]; 

		GameObject ammoCase = Ammo; 
		ammoCase.GetComponent<AmmoKit>().typeAmmonation = typeWeapon; 
		ammoCase.GetComponent<AmmoKit>().countAmmonation = ammoInCase; 
		
		Instantiate(ammoCase, spawner.transform.position, Quaternion.identity); 
	}

	private void SpawnHealing(int indexMediKit, GameObject spawner)
	{
		GameObject healthCase = MediKit;
		healthCase.GetComponent<MediKit>().indexMediKit = indexMediKit; 
		Instantiate(healthCase, spawner.transform.position, Quaternion.identity); 
	}

	public void Spawner(int waveCount)
    {
		for(int i = 0; i < AmmoSpawners.Length; i++)
        {
			SpawnAmmo(Random.Range(1, 3), Random.Range(1, 4), AmmoSpawners[i]);
			SpawnHealing(Random.Range(0, 3), MediKitSpawners[i]);
		}
    }
}
