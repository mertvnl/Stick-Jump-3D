using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float speed = 250f;
    public float transformMovementSpeed = 20f;
    public bool canMove = false;
    public bool canScore = false;
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

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(()=> canMove = true);
        EventManager.OnLevelEnd.AddListener(FinishLevel);
        EventManager.OnLevelFail.AddListener(Die);
        EventManager.OnGameStart.AddListener(InitializePlayer);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(()=> canMove = true);
        EventManager.OnLevelEnd.RemoveListener(FinishLevel);
        EventManager.OnLevelFail.RemoveListener(Die);
        EventManager.OnGameStart.RemoveListener(InitializePlayer);
    }
    
    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameStarted && canMove)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Rigidbody.velocity.y / 10 , 1);
            // Rigidbody.velocity = dir * (speed * Time.fixedDeltaTime);
            transform.position += Vector3.forward * (transformMovementSpeed * Time.fixedDeltaTime);
            Animator.SetTrigger("Run");
        }

        if (canScore)
        {
            GameManager.Instance.gameData.score++;
        }

    }

    public void Jump()
    {
        StartCoroutine(JumpCo());
    }

    IEnumerator JumpCo()
    {
        ParticleManager.Instance.PlayPlayerJumpEffect();
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);
        // ParticleManager.Instance.PlaySpeedEffect();
        GetComponentInChildren<TrailRenderer>().enabled = true;
        canScore = true;
        // canMove = false;
        Animator.SetTrigger("Fly");
        GetComponent<CapsuleCollider>().isTrigger = true;
        Rigidbody.velocity = new Vector3(0,1,2f) * TheStick.Instance.transform.localScale.y * 5;
        TheStick.Instance.isJumping = false;
        yield return new WaitForSeconds(1f);
        GetComponent<CapsuleCollider>().isTrigger = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("FinishPlatform"))
        {
            EventManager.OnLevelEnd.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            EventManager.OnLevelFail.Invoke();
        }
    }

    private void InitializePlayer()
    {
        GameManager.Instance.gameData.currentPlayer = this.gameObject;
        GameManager.Instance.gameData.fullDistance =
            (JumpPoint.Instance.transform.position - transform.position).sqrMagnitude;
    }

    private void FinishLevel()
    {
        Animator.SetTrigger("Dance");
        transform.LookAt(Vector3.back);
        GameManager.Instance.isGameStarted = false;
        canMove = false;
        canScore = false;
        Camera.main.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Die()
    {
        //TODO die
        GetComponentInChildren<TrailRenderer>().enabled = false;
        Camera.main.transform.GetChild(0).gameObject.SetActive(false);
        Animator.SetTrigger("Fall");
        GameManager.Instance.isGameStarted = false;
        canMove = false;
        canScore = false;
    }
}
