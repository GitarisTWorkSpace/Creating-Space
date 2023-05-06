using UnityEngine;

public class Difficulty
{
    private int countZombie;
    private int indexSpawner;
    
    public int SetWaveInfo(string difficulty, int numOfWave, GameObject spawnerZombie)
    {
        switch (difficulty) 
        {
            case "Easy":
                
            case "Medium":
                return Medium(numOfWave, spawnerZombie);
            case "Hard":
                return Hard(numOfWave, spawnerZombie);
            default:
                return Easy(numOfWave, spawnerZombie);
        }
    }

    public float ZombieDamage(string difficulty)
    {
        switch (difficulty) 
        {
            case "Easy":
                return 20f;
            case "Medium":
                return 40f;
            case "Hard":
                return 50f;
            default:
                return 20f;
        }
    }

    private int Easy(int numOfWave, GameObject spawnerZombie)
    {
        switch (numOfWave)
        {
            case 1:
                countZombie = 2;
                indexSpawner = 0;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                return 4;
            case 2:
                countZombie = 5;
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 3;
                StartSpawn(spawnerZombie, numOfWave);
                return 10;
            case 3:
                countZombie = 7;
                indexSpawner = 2;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 0;
                StartSpawn(spawnerZombie, numOfWave);
                return 14;
            default:
                return 0;
        }
    }

    private int Medium(int numOfWave, GameObject spawnerZombie)
    {
        switch (numOfWave)
        {
            case 1:
                countZombie = 3;
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                Debug.Log("Spawn1");
                indexSpawner = 2;
                StartSpawn(spawnerZombie, numOfWave);
                Debug.Log("Spawn2");
                return 6;
            case 2:
                countZombie = 5;
                indexSpawner = 2;
                StartSpawn(spawnerZombie, numOfWave);
                Debug.Log("Spawn1");
                indexSpawner = 3;
                StartSpawn(spawnerZombie, numOfWave);
                Debug.Log("Spawn2");
                indexSpawner = 0;
                StartSpawn(spawnerZombie, numOfWave);
                Debug.Log("Spawn3");
                return 15;
            case 3:
                countZombie = 8;
                indexSpawner = 0;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 3;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                return 24;
            default:
                return 0;
        }
    }

    private int Hard(int numOfWave, GameObject spawnerZombie)
    {
        switch (numOfWave)
        {
            case 1:
                countZombie = 4;
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 2;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 3;
                StartSpawn(spawnerZombie, numOfWave);
                return 12;
            case 2:
                countZombie = 5;
                indexSpawner = 0;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 2;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 3;
                StartSpawn(spawnerZombie, numOfWave);
                return 20;
            case 3:
                countZombie = 8;
                indexSpawner = 2;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 0;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 3;
                StartSpawn(spawnerZombie, numOfWave);
                indexSpawner = 1;
                StartSpawn(spawnerZombie, numOfWave);
                return 32;
            default:
                return 0;
        }
    }

    private void StartSpawn(GameObject spawnerZombie, int numOfWave)
    {
        spawnerZombie.GetComponent<SpawnZombie>().StartCoroutine(spawnerZombie.GetComponent<SpawnZombie>().Spawner(countZombie, indexSpawner, numOfWave));
    }
}
