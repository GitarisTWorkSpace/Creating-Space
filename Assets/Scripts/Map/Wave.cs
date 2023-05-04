using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] public GameObject SpawnerZombie;
    [SerializeField] public GameObject SpawnerItems;
    [SerializeField] public GameObject HUD;
    [SerializeField] public int numOfWave;
    [SerializeField] public bool waveIsEnd;
    [SerializeField] public string difficulty;

    public void StartWave()
    {
        difficulty = HUD.GetComponent<MainSettings>().difficulty;
        var difficult = new Difficulty();
        difficult.SetWaveInfo(difficulty, numOfWave, SpawnerZombie);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            StartWave();
        }
    }

    private void Update()
    {
        if (waveIsEnd)
        {
            SpawnerItems.GetComponent<ItemSpawner>().Spawner(numOfWave);
            waveIsEnd = false;
        }
    }
}