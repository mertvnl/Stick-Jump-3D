using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpPoint : Singleton<JumpPoint>
{
    public bool canRotate = false;
    public GameObject stickPivot;
    public float rotateSpeed = 200f;
    private void OnTriggerEnter(Collider other)
    {
        TheStick stick = other.GetComponent<TheStick>();
        if (stick != null)
        {
            stickPivot = stick.gameObject;

            canRotate = true;
            Debug.Log("rotate");
        }
    }

    private void FixedUpdate()
    {
        if (canRotate)
        {
            stickPivot.transform.Rotate(Vector3.right * (200f * Time.fixedDeltaTime));
        }
    }
    
}
