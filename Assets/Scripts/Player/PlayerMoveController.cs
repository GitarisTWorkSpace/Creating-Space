using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
	#region Mause Controller
	[Header("Mause Controller")]

	[SerializeField] public Camera PlayerCamera;
    [SerializeField] public GameObject Player;

	
    [SerializeField] public float sensivity;
    [SerializeField] private float smoothTime;

    private float xRotation;
    private float yRotation;

    private float xRotCurrent;
    private float yRotCurrent;

    private float currentVelosityX;
    private float currentVelosityY;
    #endregion

    #region Movement Controller
    [Header("Movement Controller")]
    private CharacterController player;
    private Vector3 moveDirection;

    [SerializeField] private float maxValueStamina;
    [SerializeField] private float minValueStamina;
    [SerializeField] private float staminaMinus;
    [SerializeField] private float staminaPlus;

    [SerializeField] private float speedRun;
    [SerializeField] private float speedMove;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float speedCurrent;

    public float staminaValue;
    private float xMove;
    private float zMove;
	#endregion

	private void Awake() 
	{
        player = GetComponent<CharacterController>();
        staminaValue = maxValueStamina;
    }

    private void MoveMouse()
    {
        xRotation += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRotation, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRotation, ref currentVelosityY, smoothTime);

        PlayerCamera.transform.rotation = Quaternion.Euler(-xRotCurrent, yRotCurrent, 0);
        Player.transform.rotation = Quaternion.Euler(0, yRotCurrent, 0);
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

        player.Move(moveDirection * speedCurrent * Time.deltaTime);
    }

    private void Stamina()
    {
    	if (staminaValue > maxValueStamina) staminaValue = maxValueStamina;
  	    if (staminaValue < minValueStamina) staminaValue = minValueStamina;

		if (Input.GetKey(KeyCode.LeftShift) && staminaValue > 0)
        {
            speedCurrent = Mathf.Lerp(speedCurrent, speedRun, smoothSpeed * Time.deltaTime);
            staminaValue -= staminaMinus;
        }
        else
        {
            speedCurrent = Mathf.Lerp(speedCurrent, speedMove, smoothSpeed * Time.deltaTime);
            staminaValue += staminaPlus * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
    	MoveMouse();
		MovePlayer();
        Stamina();
    }
}
