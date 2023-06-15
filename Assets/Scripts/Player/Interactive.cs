using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private HeadUpDisplay HUD;
    [SerializeField] private float distanceToObj = 5;
    [SerializeField] private bool activePressE;

    private void Update()
    {
        InteractiveItem();
        
        if (Input.GetKeyDown(KeyCode.Escape))
            HUD.ActivePausePanel(true);

        HUD.ActivePressButton(activePressE);
    }

    private void InteractiveItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, distanceToObj))
        {
            switch(hit.transform.tag)
            {
                case "Weapon": PickUpWeapon(hit.transform.gameObject); break;
                case "Note": ReaderPanel(hit.transform.gameObject); break;
                case "Door": OpenDoor(hit.transform.gameObject); break;
                case "KeyDoor": GetKeyToDoor(hit.transform.gameObject); break;
                default: activePressE = false; break;
            }
        }
    }

    private void PickUpWeapon(GameObject currentObj)
    {
        activePressE = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentObj.GetComponent<Rigidbody>().isKinematic = true;
            currentObj.transform.parent = transform;
        }
    }

    private void ReaderPanel(GameObject currentObj)
    {
        activePressE = true;
        if (Input.GetKeyDown(KeyCode.E))
            HUD.GetReaderPanelInfo(currentObj.GetComponent<Note>().HeaderText, currentObj.GetComponent<Note>().MainText);
    }

    private void OpenDoor(GameObject currentObj)
    {
        activePressE = true;
        if (Input.GetKeyDown(KeyCode.E))        
            currentObj.GetComponent<Door>().Open();
    }
    
    private void GetKeyToDoor(GameObject currentObj)
    {
        activePressE = true;
        if (Input.GetKeyDown(KeyCode.E))        
            currentObj.GetComponent<KeyDoor>().OpenDoorWithKey();
    }

}
