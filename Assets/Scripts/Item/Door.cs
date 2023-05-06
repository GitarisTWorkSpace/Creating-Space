using UnityEngine;

public class Door : MonoBehaviour
{ 
	[SerializeField] private Animator Animator;
	public bool isOpened = true;
	public bool needKey = false;

	public void Open()
	{
		Animator.SetBool("DoorIsOpen", isOpened);
		isOpened = !isOpened;
	}
}