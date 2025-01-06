using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveInterval = 0.5f;
    private Vector3 direction = Vector3.right;
    private float moveTimer;

    void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveInterval)
        {
            Move();
            moveTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W)) direction = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.S)) direction = Vector3.back;
        if (Input.GetKeyDown(KeyCode.A)) direction = Vector3.left;
        if (Input.GetKeyDown(KeyCode.D)) direction = Vector3.right;
    }

    void Move()
    {
        transform.position += direction;
    }
}
