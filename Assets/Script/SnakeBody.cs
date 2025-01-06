using UnityEngine;
using System.Collections.Generic;

public class SnakeBody : MonoBehaviour
{
    public Transform head; // Reference to the snake's head
    public GameObject bodyPrefab; // Prefab for the snake's body segments
    public float distanceBetweenSegments = 0.5f; // Distance between each segment

    private List<Transform> bodyParts = new List<Transform>(); // List of body parts
    private List<Vector3> positions = new List<Vector3>(); // List of all positions the head has been

    void Start()
    {
        // Add the initial head position to the list of positions
        positions.Add(head.position);
    }

    void Update()
    {
        // Record the head's current position if it has moved enough
        if (Vector3.Distance(positions[positions.Count - 1], head.position) > distanceBetweenSegments)
        {
            positions.Add(head.position);
        }

        // Move each body part to follow the previous segment's position
        for (int i = 0; i < bodyParts.Count; i++)
        {
            Vector3 targetPosition = positions[Mathf.Max(0, positions.Count - 1 - (i ))];
            bodyParts[i].position = Vector3.Lerp(bodyParts[i].position, targetPosition, Time.deltaTime * 10f);
        }

        // Trim the positions list to keep it from growing indefinitely
        if (positions.Count > bodyParts.Count + 1)
        {
            positions.RemoveAt(0);
        }
    }

    // Method to add a new body part
    public void AddBodyPart()
    {
        if (bodyPrefab == null)
        {
            Debug.LogError("Body prefab is not assigned!");
            return;
        }

        // Instantiate a new body part at the last body's position (or the head's if it's the first)
        Vector3 spawnPosition = bodyParts.Count == 0 ? head.position : bodyParts[bodyParts.Count - 1].position;
        GameObject newBodyPart = Instantiate(bodyPrefab, spawnPosition, Quaternion.identity);

        // Parent the new body part under the snake for organization
        newBodyPart.transform.parent = transform;

        // Add the new body part to the list of body parts
        bodyParts.Add(newBodyPart.transform);

        // Add the new body part's position to the list of positions
        positions.Add(newBodyPart.transform.position);

        Debug.Log("New body part added at position: " + spawnPosition);
    }
}
