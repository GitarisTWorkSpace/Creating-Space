using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3f;// время жизни пули

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie"){
            collision.gameObject.GetComponent<Zombie>().healthPointZ -= 30f;
        }
        Destroy(gameObject);
    }
}
