using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float staminaValue = 100;
    [SerializeField] float maxValueStamina;
    [SerializeField] float minValueStamina;
    [SerializeField] float staminaMinus;
    [SerializeField] float staminaPlus;


    [SerializeField] private float speedMove;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedCurrent;
    float xMove;
    float zMove;
    CharacterController player;
    Vector3 moveDirection;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void MovePlayer()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0, zMove);
            moveDirection = transform.TransformDirection(moveDirection);
        }
        moveDirection.y -= 0.1f;

        if (Input.GetKey(KeyCode.LeftShift) && staminaValue > 0)
        {
            speedCurrent = speedRun;
            staminaValue -= staminaMinus;
        }
        else
        {
            speedCurrent = speedMove;
            staminaValue += staminaPlus * Time.deltaTime;
        }

        player.Move(moveDirection * speedCurrent);
    }

    private void Stamina()
    {
        if (staminaValue > maxValueStamina) staminaValue = maxValueStamina;
        if (staminaValue < minValueStamina) staminaValue = minValueStamina;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Stamina();
    }
}
