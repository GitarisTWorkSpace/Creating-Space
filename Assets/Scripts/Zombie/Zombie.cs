using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] public float healthPointZ = 150f;
    [SerializeField] public float damage = 10f;
    [SerializeField] private float deathTime = 2f;

    // Update is called once per frame
    void Update()
    {
        if (healthPointZ <= 0){
            Destroy(gameObject, deathTime);
        }
    }
}
