using UnityEngine;
using System.Diagnostics;
using System;
using DG.Tweening;
using Sirenix.Utilities;
using Debug = UnityEngine.Debug;

public class ObstacleController : MonoBehaviour
{
    public float RotateSpeed;
    public bool CanRotate;
    public float MoveDistance;
    public float MoveTime;
    public float MoveDistanceBack;
    public float MoveDistanceForward;

    public bool CanMoveRight;
    public bool CanMoveLeft;

    public bool CanMoveForward;
    public bool CanMoveBack;

    private void FixedUpdate()
    {
        ObstacleMovement();
    }

    private void ObstacleMovement()
    {
        if (CanRotate)
        {
            // transform.RotateAround(transform.position , Vector3.up , 360 * Time.fixedDeltaTime );
            transform.RotateAround(transform.position, Vector3.up, 1 * Time.fixedDeltaTime * RotateSpeed);
        }

        if (GameManager.Instance.isGameStarted)
        {
            if (CanMoveRight)
            {
                transform.DOMoveX(MoveDistance, MoveTime).OnComplete(() => CanMoveLeft = true);
                CanMoveRight = false;
            }

            if (CanMoveLeft)
            {
                transform.DOMoveX(-MoveDistance, MoveTime).OnComplete(() => CanMoveRight = true);
                CanMoveLeft = false;
            }

            if (CanMoveForward)
            {
                transform.DOMoveZ(MoveDistanceBack, MoveTime).OnComplete(() => CanMoveBack = true);
                CanMoveForward = false;
            }

            if (CanMoveBack)
            {
                transform.DOMoveZ(MoveDistanceForward, MoveTime).OnComplete(() => CanMoveForward = true);
                CanMoveBack = false;
            }
        }
    }
}