using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombie;
    public GameObject[] zSpawners;

    public int count = 5;
    public int indexSpawwners = 0;

    public bool waveIsDone = false;

    private void SpawnZ(GameObject spawner)
    {
        Vector3 spawn = new Vector3(spawner.transform.position.x + Random.Range(0, 2), spawner.transform.position.y + Random.Range(0, 2), spawner.transform.position.z);
        Instantiate(zombie, spawner.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (waveIsDone)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnZ(zSpawners[indexSpawwners]);
            }
            waveIsDone = false;
        }
    }
}
