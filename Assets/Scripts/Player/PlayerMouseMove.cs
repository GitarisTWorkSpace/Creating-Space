using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseMove : MonoBehaviour
{
    [SerializeField] private float sensivity;
    [SerializeField] private float smoothTime;
    float xRotation;
    float yRotation;
    float xRotCurrent;
    float yRotCurrent;
    public Camera playerCamera;
    public GameObject player;
    public GameObject handWeapon;

    float currentVelosityX;
    float currentVelosityY;

    private void MoveMouse()
    {
        xRotation += Input.GetAxis("Mouse Y") * sensivity;
        yRotation += Input.GetAxis("Mouse X") * sensivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRotation, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRotation, ref currentVelosityY, smoothTime);

        playerCamera.transform.rotation = Quaternion.Euler(-xRotCurrent, yRotCurrent, 0);
        player.transform.rotation = Quaternion.Euler(0, yRotCurrent, 0);
        handWeapon.transform.rotation = Quaternion.Euler(-xRotCurrent, yRotCurrent, 0);
    }

    private void FixedUpdate()
    {
        MoveMouse();
    }
}
