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

        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            //Check if any run animation is playing. If so don't trigger the run animation to avoid any overlap
            if (!player.Animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
            {
                player.Animator.SetTrigger("Run");
            }
            
        }
    }
}
