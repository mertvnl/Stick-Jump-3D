using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float speed = 250f;
    public float transformMovementSpeed = 20f;
    public bool canMove = false;
    public bool canScore = false;
    public GameObject stickPrefab;
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
        EventManager.OnLevelStart.AddListener(CallOnLevelStart);
        EventManager.OnLevelEnd.AddListener(FinishLevel);
        EventManager.OnLevelFail.AddListener(Die);
        EventManager.OnGameStart.AddListener(InitializePlayer);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(CallOnLevelStart);
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
        GetComponentInChildren<TrailRenderer>().enabled = true;
        canScore = true;
        // canMove = false;
        Animator.SetTrigger("Fly");
        GetComponent<CapsuleCollider>().isTrigger = true;
        Rigidbody.velocity = new Vector3(0,1,2f) * TheStick.Instance.transform.localScale.y * 5;
        TheStick.Instance.isJumping = false;
        yield return new WaitForSeconds(1f);
        Destroy(TheStick.Instance.gameObject);
        CreateStick();
        GetComponent<CapsuleCollider>().isTrigger = false;
    }

    
    //Platform interface'i oluştur.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("FinishPlatform"))
        {
            EventManager.OnLevelEnd.Invoke();
        }

        if (other.gameObject.CompareTag("LevelPlatform"))
        {
            Animator.SetTrigger("RunWOstick");
            Camera.main.transform.GetChild(0).gameObject.SetActive(false);
            GetComponentInChildren<TrailRenderer>().enabled = false;
            canScore = false;
            Rigidbody.velocity = Vector3.zero;
        }
        if (other.gameObject.CompareTag("LastPlatform"))
        {
            Animator.SetTrigger("RunWOstick");
            Camera.main.transform.GetChild(0).gameObject.SetActive(false);
            GetComponentInChildren<TrailRenderer>().enabled = false;
            canScore = false;
            Rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            EventManager.OnLevelFail.Invoke();
        }
    }

    private void CallOnLevelStart()
    {
        canMove = true;
        Animator.SetTrigger("Run");
    }
    private void InitializePlayer()
    {
        GameManager.Instance.gameData.currentPlayer = this.gameObject;
        GameManager.Instance.gameData.fullDistance =
            (LastJumpPoint.Instance.transform.position - transform.position).sqrMagnitude;
    }

    private void FinishLevel()
    {
        Animator.SetTrigger("Dance");
        Destroy(TheStick.Instance.gameObject);
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

    [Button]
    public void CreateStick()
    {
        Instantiate(stickPrefab, transform.position, Quaternion.identity, transform);
    }
}
