using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] balls;
    public List<Transform> spawnPoints;

    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnBalls();
    }

    void SpawnBalls()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(balls[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
    }

}