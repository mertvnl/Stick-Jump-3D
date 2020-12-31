using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StickHolder : MonoBehaviour
{
    public Transform hand;
    private void Update()
    {
        transform.position = hand.position;
    }
}
