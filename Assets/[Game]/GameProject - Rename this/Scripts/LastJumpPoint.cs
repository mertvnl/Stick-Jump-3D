using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LastJumpPoint : Singleton<LastJumpPoint>
{
    public bool canRotate = false;
    public GameObject stickPivot;
    public float rotateSpeed = 100f;

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(()=>GameManager.Instance.gameData.currentJumpPoint = this.gameObject);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(()=>GameManager.Instance.gameData.currentJumpPoint = this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        TheStick stick = other.GetComponent<TheStick>();
        if (stick != null)
        {
            stickPivot = stick.gameObject;
            canRotate = true;
        }
    }

    private void FixedUpdate()
    {
        if (canRotate && stickPivot != null)
        {
            stickPivot.transform.Rotate(Vector3.right * (rotateSpeed * Time.fixedDeltaTime));
        }
    }
    
}
