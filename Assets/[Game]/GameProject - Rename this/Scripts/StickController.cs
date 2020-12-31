using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickController : MonoBehaviour
{
    public float stickSizeToGain = 0.1f;
    public GameObject currentObstacle = null;
    public Transform StickTop;
    public GameObject stickPrefab;

    private void OnEnable()
    {
        GameManager.Instance.gameData.playerStick = this;
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
    public void StickCut(GameObject obstacle)
    {
        float offset = StickTop.position.y - obstacle.gameObject.transform.position.y;
        GameManager.Instance.gameData.fallingStickSizeY = offset;
        Vector3 newStickSize = new Vector3(0, offset / 2, 0);
        transform.position -= newStickSize;
        transform.localScale -= newStickSize;
        
    }
    public void CreateFallingStick(float yPosToCreate)
    {
        Vector3 newPos = new Vector3(transform.position.x, yPosToCreate, transform.position.z);
        Instantiate(stickPrefab, newPos, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        ObstacleController obstacle = other.gameObject.GetComponent<ObstacleController>();
        if (obstacle != null)
        {
            StickCut(other.gameObject);
            CreateFallingStick(other.gameObject.transform.position.y + GameManager.Instance.gameData.fallingStickSizeY / 2);
            Debug.Log(other.gameObject.transform.position.y);
        }
        Debug.Log(other.gameObject.name);
    }
}
