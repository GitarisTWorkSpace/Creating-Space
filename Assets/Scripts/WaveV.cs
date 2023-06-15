using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveV : MonoBehaviour
{
    [SerializeField] public GameObject wave;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            wave.SetActive(true);
    }

    private void Update()
    {
        if (wave.transform.childCount == 0) Destroy(gameObject);
    }
}
