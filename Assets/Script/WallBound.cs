using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBound : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            //Debug.Log("dedxe");
            Snake.instance.moveSpeed = 0;

        }
    }
}
