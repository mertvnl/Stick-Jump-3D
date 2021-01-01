using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StickTop : MonoBehaviour
{
    public HingeJoint joint;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            JumpPoint.Instance.canRotate = false;
            // PlayerMovement.Instance.transform.DOMoveZ(TheStick.Instance.transform.localScale.y * transform.position.z, 4);
            // PlayerMovement.Instance.transform.DOJump(PlayerMovement.Instance.transform.position * TheStick.Instance.transform.localScale.y, TheStick.Instance.transform.localScale.y * 5, 1, 5);
            
            Debug.Log("Create joint");
            // joint = TheStick.Instance.gameObject.AddComponent<HingeJoint>();
            // joint.connectedBody = other.rigidbody;
            // joint.enableCollision = true;
            TheStick.Instance.GetComponent<Rigidbody>().isKinematic = false;
            TheStick.Instance.GetComponent<CapsuleCollider>().isTrigger = false;
            Rigidbody[] rbArr = TheStick.Instance.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rbArr)
            {
                rb.constraints = RigidbodyConstraints.None;
                Debug.Log(rb.gameObject.name);
            }
            // TheStick.Instance.transform.DOJump(TheStick.Instance.transform.position + transform.forward * 5, 20, 1, 2);
            PlayerMovement.Instance.Jump();
            GetComponentInParent<TheStick>().isJumping = true;
            GetComponentInParent<TheStick>().transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
