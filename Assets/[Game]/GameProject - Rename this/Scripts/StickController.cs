using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public float stickSizeToGain = 0.1f;
    public GameObject currentObstacle = null;

    private void OnEnable()
    {
        GameManager.Instance.gameData.playerStick = this;
    }

    public void StickCut()
    {
        // Vector3 newStickSize = new Vector3(0, 2.1f, 0);
        // Vector3 newStickPos = new Vector3(0, 1.3f, 0);
        // transform.position = newStickPos;
        // transform.localScale = newStickSize;
    }
    
    
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StickUp();
        }
    }

    public void StickUp()
    {
        Vector3 newStickSize = new Vector3(0, stickSizeToGain, 0);
        transform.position += newStickSize;
        transform.localScale += newStickSize;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentObstacle = other.gameObject;
        StickCut();
    }
}
