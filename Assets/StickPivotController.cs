using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class StickPivotController : MonoBehaviour
{
    public Transform rightHand;
    private Vector3 newPos;


    private void Update()
    {
        newPos = new Vector3(rightHand.position.x, transform.position.y, rightHand.position.z);
        transform.position = newPos;
    }
}

