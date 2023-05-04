using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public GameObject Player;

    [SerializeField] public float distance = 15f;

    private GameObject currentWeapon;

    private void PickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Weapon")
            {
                currentWeapon = hit.transform.gameObject;
                SetProperty(currentWeapon);
                
                SetPosition(currentWeapon);

                SetInInvenetory(currentWeapon);
            }
        }
    }

    private void SetProperty(GameObject currentWeapon)
    {
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
        currentWeapon.GetComponent<Weapon>().isActive = true;
        currentWeapon.GetComponent<Weapon>().SendInformation();
    }

    private void SetInInvenetory(GameObject currentWeapon)
    {
        Debug.Log(transform.childCount);
        Player.GetComponent<Inventory>().WeaponInInventory[transform.childCount - 1] = currentWeapon;
        Player.GetComponent<Inventory>().SetWeapon(transform.childCount - 1);
    }

    private void SetPosition(GameObject currentWeapon)
    {
        currentWeapon.transform.parent = transform;
        currentWeapon.transform.localPosition = new Vector3(0.6f, -1.45f, 2.7f);
        currentWeapon.transform.localEulerAngles = new Vector3(0, -90f, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
    }
}
