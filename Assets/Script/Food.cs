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

            UiManager.instance.score += 10;
            UiManager.instance.scoreText.text = UiManager.instance.score.ToString();

            SnakeBody snakeBody = other.GetComponentInParent<SnakeBody>();
            if (snakeBody != null)
            {
                snakeBody.AddBodyPart();
            }

            
        }
    }



}

