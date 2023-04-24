using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;
    public float distance = 15f;
    GameObject currentWeapon;
    bool canPickUp;

    private void PickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Weapon")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Weapon>().isActive = true;
               // player.GetComponent<Inventory>().indexOfWepon = currentWeapon.GetComponent<Weapon>().indexWeapon;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = new Vector3(0.6f , -1.45f, 2.7f);
                currentWeapon.transform.localEulerAngles = new Vector3(0, -90f, 0);
                canPickUp = true;
            }
        }
    }

    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Weapon>().isActive = false;
        //player.GetComponent<Inventory>().indexOfWepon = 0;
        canPickUp = false;
        currentWeapon = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }
}
