using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] public GameObject SpawnerZombie;
    [SerializeField] public GameObject SpawnerItems;
    [SerializeField] public int waveCount;
    [SerializeField] public int countZombie;
    [SerializeField] public int indexspawner;
    [SerializeField] public bool waveIsEnd;

    public void GetWaveInformation()
    {
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            StartCoroutine(SpawnerZombie.GetComponent<SpawnZombie>().Spawner(countZombie, indexspawner));
        }
    }

    private void Update()
    {
        if (waveIsEnd)
        {
            SpawnerItems.GetComponent<ItemSpawner>().Spawner(waveCount);
            waveIsEnd = false;
        }
    }
}