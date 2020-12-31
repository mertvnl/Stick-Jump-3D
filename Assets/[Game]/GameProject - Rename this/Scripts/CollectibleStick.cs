using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StickController stick = other.GetComponentInChildren<StickController>();
        if (stick != null)
        {
            Debug.Log("collided with stick parent");
            stick.StickUp();
            Destroy(gameObject);
        }
    }
}
