using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float xMove;
    [SerializeField] private float zMove;
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
        player.Move(moveDirection * speedMove);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
