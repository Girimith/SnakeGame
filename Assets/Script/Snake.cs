using UnityEngine;

public class Snake : MonoBehaviour
{
    public static Snake instance;
    public float moveSpeed = 1f;   // Speed of the snake
    public float turnSpeed = 200f; // Turning speed
    public FixedJoystick joystick; // Reference to the fixed joystick

    private Vector3 movement;      // Stores movement direction

    private void Awake()
    {
        instance = this;
    }


    private void AddDelay()
    {
        if (UiManager.instance.gameStart)
        {
            // Get joystick input
            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            // Determine direction based on joystick input
            movement = new Vector3(horizontal, 0f, vertical).normalized;

            // Rotate snake head if there's movement
            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }

            // Move the snake forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {

        Invoke("AddDelay", 4f);
    }
}
