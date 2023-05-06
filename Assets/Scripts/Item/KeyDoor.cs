using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private GameObject Door;

    public void GetKey()
    {
        Door.GetComponent<Door>().needKey = false;
        Destroy(gameObject);
    }
}
