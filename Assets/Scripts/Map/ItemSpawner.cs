using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[SerializeField] public GameObject Ammo; // Объект патроны
	[SerializeField] public GameObject Player; // Игрок
	[SerializeField] public GameObject MediKit; // Объект аптечки

	[SerializeField] public GameObject[] MediKitSpawners; // Спавнера аптечек
	[SerializeField] public GameObject[] AmmoSpawners; // Спавнера патронов

	[SerializeField]public int[] maxAmmoInWeapon; // максимальное кол-во патронов в магазине оружия

	public bool waveIsDone = false; // Закончилась ли волна

	private void SpawnAmmo(int indexWeapon, int ammonaiton, GameObject spawner)
	{
		int ammoInCase = ammonaiton * maxAmmoInWeapon[indexWeapon]; // Сколько будет патронов в Объекте
		GameObject ammoCase = Ammo; // Создаем новый объект 
		
		// Вводим нужные поля
		ammoCase.GetComponent<AmmoKit>().indexOfWepon = indexWeapon; // Индекс оружия
		ammoCase.GetComponent<AmmoKit>().ammo = ammoInCase; // Кол-во патронов 
		
		Instantiate(ammoCase, spawner.transform.position, Quaternion.identity); // Создаем
	}

	private void SpawnHealing(float health, GameObject spawner)
	{
		GameObject healthCase = MediKit; // Создаем новый объект
		// Вводим нужные поля
		healthCase.GetComponent<MediKit>().healthPoint = health; // Какое кол-во здоровья прибавиться
		Instantiate(healthCase, spawner.transform.position, Quaternion.identity); // Создаем
	}

    private void FixedUpdate()
    {
        if (waveIsDone) // Если волна закончилась 
        {
			for (int i = 0; i < AmmoSpawners.Length; i++) // Спавним объекты
            {
				SpawnAmmo(Random.Range(1, 3), Random.Range(1, 5), AmmoSpawners[i]);
				SpawnHealing(Random.Range(1, 5) * 10, MediKitSpawners[i]);
			}
			waveIsDone = false;
        }
    }
}
