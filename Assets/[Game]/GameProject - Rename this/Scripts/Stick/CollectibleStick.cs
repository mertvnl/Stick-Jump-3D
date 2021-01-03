using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TheStick stick = other.GetComponentInChildren<TheStick>();
        if (stick != null)
        {
            stick.StickUp();
            Destroy(gameObject);
            ParticleManager.Instance.PlayStickCollect();
        }
    }
}
