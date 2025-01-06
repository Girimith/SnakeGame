using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBound : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            Snake.instance.moveSpeed = 0;

            UiManager.instance.losePanel.SetActive(true);
            UiManager.instance.gamepanel.SetActive(false);
            UiManager.instance.Bg.gameObject.SetActive(true);

            //UiManager.instance.gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        }
    }
}
