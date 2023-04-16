using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombie; // Объект Зомби
    public GameObject[] zSpawners; // Спавнера

    public int count = 5; // Кол-во зомби будет спавниться
    public int indexSpawwners = 0; // Индекс спавнера

    public bool waveIsDone = false; // Волна закончилась

    private void SpawnZ(GameObject spawner)
    {
        Vector3 spawn = new Vector3(spawner.transform.position.x + Random.Range(0, 2), spawner.transform.position.y + Random.Range(0, 2), spawner.transform.position.z);
        Instantiate(zombie, spawner.transform.position, Quaternion.identity); // спавним зомби
    }

    private void Update()
    {
        if (waveIsDone) // Если волна закончилась спавним кол-во зомби
        {
            for (int i = 0; i < count; i++)
            {
                SpawnZ(zSpawners[indexSpawwners]);
            }
            waveIsDone = false;
        }
    }
}
