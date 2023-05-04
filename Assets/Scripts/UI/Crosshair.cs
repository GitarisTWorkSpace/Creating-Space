using UnityEngine;

public class Crosshair : MonoBehaviour
{
	[SerializeField] public RectTransform crosshair;

	[SerializeField] private float sizeState;
	[SerializeField] private float sizeMove;
	[SerializeField] private float sizeCurrent;
	[SerializeField] private float sizeSpeed;

	bool isMoving
	{
		get
		{
			if (Input.GetAxis("Horizontal") != 0 ||
			Input.GetAxis("Vertical") != 0)
				return true;
			else
				return false;
		}
	}

	private void Update()
	{
		if (isMoving)
			sizeCurrent = Mathf.Lerp(sizeCurrent, sizeMove, sizeSpeed);
		else
			sizeCurrent = Mathf.Lerp(sizeCurrent, sizeState, sizeSpeed);

		crosshair.sizeDelta = new Vector2(sizeCurrent, sizeCurrent);
	}
}
