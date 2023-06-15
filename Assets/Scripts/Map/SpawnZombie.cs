using System.Collections;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] public GameObject Zombie;
    [SerializeField] public GameObject CountZombie;
    [SerializeField] public GameObject[] ZombieSpawners;
    [SerializeField] public GameObject[] WaveArr;

    [SerializeField] public Vector3[] spawnPosition;

    public float spanwTime = 0.2f;

    private void SetPosition(GameObject spawner,int indexPosiiton, int numOfWave)
    {
        GameObject empty = Zombie;
        Vector3 spawn = new Vector3(spawner.transform.position.x + spawnPosition[indexPosiiton].x, 
                                    spawner.transform.position.y, 
                                    spawner.transform.position.z + spawnPosition[indexPosiiton].z);
        Instantiate(empty, spawn, Quaternion.identity, CountZombie.transform); 
    }

    public IEnumerator Spawner(int count, int indexSpawner, int numOfWave)
    {
        for (int i = 0; i < count; i++)
        {
            int rnd = Random.Range(0, spawnPosition.Length + 1);
            SetPosition(ZombieSpawners[indexSpawner], rnd, numOfWave);
            yield return new WaitForSeconds(spanwTime);
        }
    }
}
