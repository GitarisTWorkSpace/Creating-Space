using UnityEngine;

public class PlayerMouseMove : MonoBehaviour
{
    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject HandWeapon;

    [SerializeField] public float sensivity;
    [SerializeField] private float smoothTime;

    private float xRotation;
    private float yRotation;
    private float xRotCurrent;
    private float yRotCurrent;

    float currentVelosityX;
    float currentVelosityY;

    private void MoveMouse()
    {
        xRotation += Input.GetAxis("Mouse Y") * sensivity;
        yRotation += Input.GetAxis("Mouse X") * sensivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRotation, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRotation, ref currentVelosityY, smoothTime);

        PlayerCamera.transform.rotation = Quaternion.Euler(-xRotCurrent, yRotCurrent, 0);
        Player.transform.rotation = Quaternion.Euler(0, yRotCurrent, 0);
        HandWeapon.transform.rotation = Quaternion.Euler(-xRotCurrent, yRotCurrent, 0);
    }

    private void FixedUpdate()
    {
        MoveMouse();
    }
}
