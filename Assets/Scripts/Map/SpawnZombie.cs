using System.Collections;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombie; // Объект Зомби
    public GameObject[] zSpawners; // Спавнера
    [SerializeField] public Vector3[] spawnPosition;

    public int count = 5; // Кол-во зомби будет спавниться
    public int indexSpawwners = 0; // Индекс спавнера
    public float spanwTime = 0.2f;

    public bool waveIsDone = false; // Волна закончилась

    private void SetPosition(GameObject spawner,int indexPosiiton)
    {

        Vector3 spawn = new Vector3(spawner.transform.position.x + spawnPosition[indexPosiiton].x, 
                                    spawner.transform.position.y, 
                                    spawner.transform.position.z + spawnPosition[indexPosiiton].z);
        Instantiate(zombie, spawn, Quaternion.identity); // спавним зомби
    }

    private IEnumerator Spawner()
    {
        for (int i = 0; i < count; i++)
        {
            int rnd = Random.Range(0, spawnPosition.Length);
            SetPosition(zSpawners[indexSpawwners], rnd);
            yield return new WaitForSeconds(spanwTime);
        }
    }

    private void Update()
    {
        if (waveIsDone) // Если волна закончилась спавним кол-во зомби
        {
            StartCoroutine(Spawner());
            waveIsDone = false;
        }
    }
}
