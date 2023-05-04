using UnityEngine;

public class Door : MonoBehaviour
{ 
	[SerializeField] private Animator Animator;
	public bool isOpened;

	public void Open()
	{
		Animator.SetBool("DoorIsOpen", isOpened);
		isOpened = !isOpened;
	}
}