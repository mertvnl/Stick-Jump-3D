using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float speed = 250f;
    public bool canMove = true;
    private Rigidbody rigidbody;
    private Animator animator;
    public Rigidbody Rigidbody
    {
        get
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }

            return rigidbody;
        }
    }

    public Animator Animator
    {
        get
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            return animator;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameStarted && canMove)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Rigidbody.velocity.y / 10 , 1);
            Rigidbody.velocity = dir * (speed * Time.fixedDeltaTime);
            Animator.SetTrigger("Run");
        }
        
    }

    public void Jump()
    {
        StartCoroutine(JumpCo());
    }

    IEnumerator JumpCo()
    {
        GetComponentInChildren<TrailRenderer>().enabled = true;
        Animator.SetTrigger("Fly");
        GetComponent<CapsuleCollider>().isTrigger = true;
        canMove = false;
        Rigidbody.velocity = new Vector3(0,1,1) * TheStick.Instance.transform.localScale.y * 5;
        TheStick.Instance.isJumping = false;
        yield return new WaitForSeconds(1f);
        GetComponent<CapsuleCollider>().isTrigger = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("FinishPlatform"))
        {
            Animator.SetTrigger("Dance");
            transform.LookAt(Vector3.back);
        }
    }
}
