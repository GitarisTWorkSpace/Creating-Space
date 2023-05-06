using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private GameObject HUD;
    [SerializeField] private float range = 15;
    RaycastHit hit;

    private void Update()
    {
       if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, range))
       {
            //Debug.Log("Смотрю в " + hit.transform.gameObject.name);

            if (Input.GetKeyDown(KeyCode.E)) DoSomething();

            InteractiveItem();
        }
    }

    private void InteractiveItem()
    {
        if (hit.transform.tag == "Door" || 
            hit.transform.tag == "Note" || 
            hit.transform.tag == "Weapon" || 
            hit.transform.tag == "KeyDoor")
            HUD.GetComponent<HeadUpDisplay>().ActivePressE(true);
        else
            HUD.GetComponent<HeadUpDisplay>().ActivePressE(false);
    }

    private void DoSomething()
    {
        if (hit.transform.tag == "Door")
        {
            if(!hit.transform.parent.gameObject.GetComponent<Door>().needKey)
            {
                hit.transform.parent.gameObject.GetComponent<Door>().Open();
            }
            else
            {
                HUD.GetComponent<HeadUpDisplay>().SetInterectebleText("Нужен ключ");
            }
        }

        if (hit.transform.tag == "Note")
            hit.transform.gameObject.GetComponent<Note>().Read();

        if(hit.transform.tag == "KeyDoor")
            hit.transform.gameObject.GetComponent<KeyDoor>().GetKey();
    }
}
