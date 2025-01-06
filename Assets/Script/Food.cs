using UnityEngine;

public class Food : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            Debug.Log("Food collected!");
            Destroy(gameObject); // Remove food from the scene

            GameManager.instance.SpawnFood();

            SnakeBody snakeBody = other.GetComponentInParent<SnakeBody>();
            if (snakeBody != null)
            {
                snakeBody.AddBodyPart();
            }

            
        }
    }



}

