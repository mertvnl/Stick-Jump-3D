using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float speed = 250f;
    private Rigidbody rigidbody;
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
    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameStarted)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Rigidbody.velocity.y / 10 , 1);
            Rigidbody.velocity = dir * (speed * Time.fixedDeltaTime);
        }
    }

    public void Jump()
    {
        Debug.Log("jumping");
        // Rigidbody.AddForce(Vector3.forward * (1000 * (TheStick.Instance.transform.localScale.y * Time.fixedDeltaTime)), ForceMode.Impulse);
        // Rigidbody.AddForce(Vector3.up * (500 * (TheStick.Instance.transform.localScale.y * Time.fixedDeltaTime)), ForceMode.Impulse);
        Rigidbody.AddForce(Vector3.up * 100 * TheStick.Instance.transform.localScale.y);
        Rigidbody.AddForce(Vector3.forward * 10000 * TheStick.Instance.transform.localScale.y, ForceMode.Acceleration);
        TheStick.Instance.isJumping = false;
    }
}
