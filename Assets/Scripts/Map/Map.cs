using UnityEngine;

public class Map : MonoBehaviour
{
	public GameObject ammo; // Объект патроны
	public GameObject player; // Игрок
	public GameObject healing; // Объект аптечки

	[SerializeField] public GameObject[] healthSpawners; // Спавнера аптечек
	[SerializeField] public GameObject[] ammoSpawners; // Спавнера патронов

	[SerializeField]public int[] maxAmmoInWeapon; // максимальное кол-во патронов в магазине оружия
	public bool waveIsDone = false; // Закончилась ли волна

	private void Start()
	{
		maxAmmoInWeapon = FindObjectOfType<Inventory>().maxCurrentAmmoInWeapon; 
		// Нахолим объект(player) у него находим скрипт Inventory и
		// смотрим на поле максимальное кол-во патронов в магазине оружия
	}

	private void SpawnAmmo(int indexWeapon, int ammonaiton, GameObject spawner)
	{
		int ammoInCase = ammonaiton * maxAmmoInWeapon[indexWeapon]; // Сколько будет патронов в Объекте
		GameObject ammoCase = ammo; // Создаем новый объект 
		
		// Вводим нужные поля
		ammoCase.GetComponent<Ammo>().indexOfWepon = indexWeapon; // Индекс оружия
		ammoCase.GetComponent<Ammo>().ammo = ammoInCase; // Кол-во патронов 
		
		Instantiate(ammoCase, spawner.transform.position, Quaternion.identity); // Создаем
	}

	private void SpawnHealing(float health, GameObject spawner)
	{
		GameObject healthCase = healing; // Создаем новый объект
		// Вводим нужные поля
		healthCase.GetComponent<Heal>().healthPoint = health; // Какое кол-во здоровья прибавиться
		Instantiate(healthCase, spawner.transform.position, Quaternion.identity); // Создаем
	}

    private void Update()
    {
        if (waveIsDone) // Если волна закончилась 
        {
			for (int i = 0; i < ammoSpawners.Length; i++) // Спавним объекты
            {
				SpawnAmmo(Random.Range(1, 3), Random.Range(1, 5), ammoSpawners[i]);
				SpawnHealing(Random.Range(1, 5) * 10, healthSpawners[i]);
			}
			waveIsDone = false;
        }
    }
}
