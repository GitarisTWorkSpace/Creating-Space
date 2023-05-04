using UnityEngine;

public class Difficulty
{
    private int countZombie;
    private int indexSpawner;
    
    public void SetWaveInfo(string difficulty, int numOfWave, GameObject spawnerZombie)
    {
        switch (difficulty) 
        {
            case "Easy":
                Easy(numOfWave, spawnerZombie);
                break;
            case "Medium":
                Medium(numOfWave, spawnerZombie);
                break;
            case "Hard":
                Hard(numOfWave, spawnerZombie);
                break;
            default: 
                Easy(numOfWave, spawnerZombie);
                break;
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

    private void Easy(int numOfWave, GameObject spawnerZombie)
    {
        switch (numOfWave)
        {
            case 1:
                countZombie = 2;
                indexSpawner = 0;
                StartSpawn(spawnerZombie);
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                break;
            case 2:
                countZombie = 5;
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                indexSpawner = 3;
                StartSpawn(spawnerZombie);
                break;
            case 3:
                countZombie = 7;
                indexSpawner = 2;
                StartSpawn(spawnerZombie);
                indexSpawner = 0;
                StartSpawn(spawnerZombie);
                break;
            default:
                return;
        }
    }

    private void Medium(int numOfWave, GameObject spawnerZombie)
    {
        switch (numOfWave)
        {
            case 1:
                countZombie = 3;
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                indexSpawner = 2;
                StartSpawn(spawnerZombie);
                break;
            case 2:
                countZombie = 5;
                indexSpawner = 2;
                StartSpawn(spawnerZombie);
                indexSpawner = 3;
                StartSpawn(spawnerZombie);
                indexSpawner = 0;
                StartSpawn(spawnerZombie);
                break;
            case 3:
                countZombie = 8;
                indexSpawner = 0;
                StartSpawn(spawnerZombie);
                indexSpawner = 3;
                StartSpawn(spawnerZombie);
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                break;
            default:
                return;
        }
    }

    private void Hard(int numOfWave, GameObject spawnerZombie)
    {
        switch (numOfWave)
        {
            case 1:
                countZombie = 4;
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                indexSpawner = 2;
                StartSpawn(spawnerZombie);
                indexSpawner = 3;
                StartSpawn(spawnerZombie);
                break;
            case 2:
                countZombie = 5;
                indexSpawner = 0;
                StartSpawn(spawnerZombie);
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                indexSpawner = 2;
                StartSpawn(spawnerZombie);
                indexSpawner = 3;
                StartSpawn(spawnerZombie);
                break;
            case 3:
                countZombie = 8;
                indexSpawner = 2;
                StartSpawn(spawnerZombie);
                indexSpawner = 0;
                StartSpawn(spawnerZombie);
                indexSpawner = 3;
                StartSpawn(spawnerZombie);
                indexSpawner = 1;
                StartSpawn(spawnerZombie);
                break;
            default:
                return;
        }
    }

    private void StartSpawn(GameObject spawnerZombie)
    {
        spawnerZombie.GetComponent<SpawnZombie>().StartCoroutine(spawnerZombie.GetComponent<SpawnZombie>().Spawner(countZombie, indexSpawner));
    }
}
