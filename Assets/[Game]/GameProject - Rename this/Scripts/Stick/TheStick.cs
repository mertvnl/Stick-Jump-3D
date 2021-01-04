using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TheStick : Singleton<TheStick>
{
    public Transform rightHand;
    public Transform StickTop;
    public GameObject stickPrefab;
    public float stickSizeToGain = 0.5f;
    public float speed = 250f;
    private Rigidbody rigidbody;
    public bool isJumping = false;
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
    private void Update()
    {
        //Set the stick position

        if (rightHand == null)
        {
            rightHand = PlayerMovement.Instance.GetComponentInChildren<RightHand>().transform;
        }
        if (rightHand != null && !isJumping)
        {
            transform.position = rightHand.position;
        }

        
        //Scale up the stick, debug purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StickUp();
        }
    }
    
    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameStarted)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Rigidbody.velocity.y / 10 , 1);
            Rigidbody.velocity = dir * (speed * Time.fixedDeltaTime);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        ObstacleController obstacle = other.gameObject.GetComponent<ObstacleController>();
        if (obstacle != null)
        {
            StickCut(other.gameObject);
            CreateFallingStick(obstacle.transform.position.y + GameManager.Instance.gameData.fallingStickSizeY / 2);
        }
    }
    
    public void StickUp()
    {
        Vector3 newStickSize = new Vector3(0, stickSizeToGain, 0);
        transform.localScale += newStickSize;
    }
    
    public void StickCut(GameObject obstacle)
    {
        float offset = StickTop.position.y - obstacle.gameObject.transform.position.y;
        ParticleManager.Instance.PlayStickCutEffect();
        GameManager.Instance.gameData.fallingStickSizeY = offset;
        Vector3 newStickSize = new Vector3(0, offset / 2, 0);
        // transform.position -= newStickSize;
        transform.localScale -= newStickSize;
    }
    
    public void CreateFallingStick(float yPosToCreate)
    {
        Vector3 newPos = new Vector3(transform.position.x, yPosToCreate, transform.position.z);
        Instantiate(stickPrefab, newPos, Quaternion.identity);
    }
}
