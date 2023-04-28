using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float staminaValue = 100;

    [SerializeField] private float maxValueStamina;
    [SerializeField] private float minValueStamina;
    [SerializeField] private float staminaMinus;
    [SerializeField] private float staminaPlus;

    [SerializeField] private float speedMove;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedCurrent;

    private float xMove;
    private float zMove;

    private CharacterController Player;

    private Vector3 moveDirection;

    private void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    private void MovePlayer()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        if (Player.isGrounded)
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

        Player.Move(moveDirection * speedCurrent);
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
