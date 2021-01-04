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
        if (other.gameObject.CompareTag("Jointable"))
        {
            // JumpPoint.Instance.canRotate = false;

            var anchorPoint = Instantiate(jointPoint, transform.position, Quaternion.identity);
            joint = anchorPoint.AddComponent<HingeJoint>();
            jointForStick = anchorPoint.AddComponent<HingeJoint>();
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
            PlayerMovement.Instance.Jump();
            GetComponentInParent<TheStick>().isJumping = true;
            GetComponentInParent<TheStick>().transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
