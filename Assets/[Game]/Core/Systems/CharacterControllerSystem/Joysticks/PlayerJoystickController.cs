using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Joystick joystick;
    private Rigidbody rigidbody;

    public Joystick Joystick
    {
        get
        {
            if (joystick == null)
            {
                joystick = GameManager.Instance.gameData.currentJoystick;
            }

            return joystick;
        }
    }

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
        Vector3 dir = new Vector3(Joystick.Horizontal, 0, 0);
        transform.position += dir * (speed * Time.fixedDeltaTime);
    }
}
