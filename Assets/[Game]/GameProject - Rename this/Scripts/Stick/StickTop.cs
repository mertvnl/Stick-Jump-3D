using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StickTop : Singleton<StickTop>
{
    public HingeJoint joint;
    public HingeJoint jointForStick;
    public GameObject jointPoint;
    public GameObject stick;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            JumpPoint.Instance.canRotate = false;
            // PlayerMovement.Instance.transform.DOMoveZ(TheStick.Instance.transform.localScale.y * transform.position.z, 4);
            // PlayerMovement.Instance.transform.DOJump(PlayerMovement.Instance.transform.position * TheStick.Instance.transform.localScale.y, TheStick.Instance.transform.localScale.y * 5, 1, 5);
            
            var anchorPoint = Instantiate(jointPoint, transform.position, Quaternion.identity);
            joint = anchorPoint.AddComponent<HingeJoint>();
            jointForStick = anchorPoint.AddComponent<HingeJoint>();
            // joint.anchor = transform.position;
            joint.connectedBody = TheStick.Instance.gameObject.GetComponent<Rigidbody>();
            jointForStick.connectedBody = stick.gameObject.GetComponent<Rigidbody>();
            joint.enableCollision = true;
            jointForStick.enableCollision = true;
            joint.axis = new Vector3(0, 0, 1);
            jointForStick.axis = new Vector3(0, 0, 1);

            TheStick.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * 1000 * TheStick.Instance.transform.localScale.y / 2;
            
            TheStick.Instance.GetComponent<Rigidbody>().isKinematic = false;
            TheStick.Instance.GetComponent<CapsuleCollider>().isTrigger = false;
            Rigidbody[] rbArr = TheStick.Instance.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rbArr)
            {
                rb.constraints = RigidbodyConstraints.None;
            }
            // TheStick.Instance.transform.DOJump(TheStick.Instance.transform.position + transform.forward * 5, 20, 1, 2);
            PlayerMovement.Instance.Jump();
            GetComponentInParent<TheStick>().isJumping = true;
            GetComponentInParent<TheStick>().transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
