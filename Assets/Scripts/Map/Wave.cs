using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] public GameObject SpawnerZombie;
    [SerializeField] public GameObject CountZombie;
    [SerializeField] public GameObject SpawnerItems;
    [SerializeField] public GameObject NextStep;
    [SerializeField] public GameObject HUD;
    [SerializeField] public int numOfWave;
    [SerializeField] public int countZombie = 1;
    [SerializeField] public bool waveIsEnd;
    [SerializeField] public bool waveIsStart;
    [SerializeField] public string difficulty;

    public void StartWave()
    {
        difficulty = HUD.GetComponent<MainSettings>().difficulty;
        var difficult = new Difficulty();
        int countZ = difficult.SetWaveInfo(difficulty, numOfWave, SpawnerZombie);
        Debug.Log(CountZombie.transform.childCount, CountZombie);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !waveIsStart)
        {
            StartWave();
            waveIsStart = true;
        }
    }

    private void Update()
    {
        countZombie = CountZombie.transform.childCount;
        if (countZombie <= 0 && waveIsStart) waveIsEnd = true;

        if (waveIsEnd)
        {
            SpawnerItems.GetComponent<ItemSpawner>().Spawner(numOfWave);
            if(NextStep != null) NextStep.SetActive(true);
            Destroy(gameObject);
        }
    }
}