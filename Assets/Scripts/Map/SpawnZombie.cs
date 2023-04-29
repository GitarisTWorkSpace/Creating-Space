using System.Collections;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] public GameObject Zombie; 
    [SerializeField] public GameObject[] ZombieSpawners; 

    [SerializeField] public Vector3[] spawnPosition;

    //public int count = 5; 
    //public int indexSpawwners = 0; 
    public float spanwTime = 0.2f;

    private void SetPosition(GameObject spawner,int indexPosiiton)
    {

        Vector3 spawn = new Vector3(spawner.transform.position.x + spawnPosition[indexPosiiton].x, 
                                    spawner.transform.position.y, 
                                    spawner.transform.position.z + spawnPosition[indexPosiiton].z);
        Instantiate(Zombie, spawn, Quaternion.identity); 
    }

    public IEnumerator Spawner(int count, int indexSpawner)
    {
        for (int i = 0; i < count; i++)
        {
            int rnd = Random.Range(0, spawnPosition.Length);
            SetPosition(ZombieSpawners[indexSpawner], rnd);
            yield return new WaitForSeconds(spanwTime);
        }
    }

    
    //private void FixedUpdate()
    //{
    //    if (waveIsStart) 
    //    {
    //        StartCoroutine(Spawner(count, indexSpawwners));
    //        waveIsStart = false;
    //    }
    //}
}
