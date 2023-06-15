using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public float distanceToObj = 5f;

    private void PickUp()
    {
        RaycastHit hit;
        GameObject currentWeapon;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, distanceToObj))
        {
            if(hit.transform.tag == "Weapon")
            {
                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.GetComponent<Animator>().SetBool("inHand", true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
    }
}
