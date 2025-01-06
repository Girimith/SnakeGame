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

            Snake snake = other.GetComponent<Snake>();
            if (snake != null)
            {
                //snake.Grow(); // Call a method to grow the snake
            }
        }
    }



}

