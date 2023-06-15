using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private GameObject Door;

    public void OpenDoorWithKey()
    {
        Door.GetComponent<Door>().needKey = false;
        Destroy(gameObject);
    }
}
