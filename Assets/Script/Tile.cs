using UnityEngine;

public class Tile : MonoBehaviour
{
    
    public Material healthyMaterial;
    public bool isHealthy = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake") && !isHealthy)
        {
            GetComponent<Renderer>().material = healthyMaterial;
            isHealthy = true;
        }
    }
}

