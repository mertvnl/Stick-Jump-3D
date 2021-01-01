using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTop : MonoBehaviour
{
    public HingeJoint joint;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            JumpPoint.Instance.canRotate = false;
            Debug.Log("Create joint");
            // joint = gameObject.AddComponent<HingeJoint>();
            // joint.connectedBody = other.rigidbody;
            // joint.enableCollision = true;
            PlayerMovement.Instance.Jump();
            GetComponentInParent<TheStick>().isJumping = true;
            GetComponentInParent<TheStick>().transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
