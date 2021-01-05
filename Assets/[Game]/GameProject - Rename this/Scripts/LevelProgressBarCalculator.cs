using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBarCalculator : MonoBehaviour
{
    public Image fillImage;
    private GameObject player;

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(()=> fillImage.fillAmount = 0);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(()=> fillImage.fillAmount = 0);
    }

    public GameObject Player
    {
        get
        {
            if (player == null)
            {
                player = GameManager.Instance.gameData.currentPlayer;
            }

            return player;
        }
    }

    private GameObject jumpPoint;

    public GameObject JumpPoint
    {
        get
        {
            if (jumpPoint == null)
            {
                jumpPoint = GameManager.Instance.gameData.currentJumpPoint;
            }

            return jumpPoint;
        }
    }
    
    float GetDistance()
    {
        return (JumpPoint.transform.position - Player.transform.position).sqrMagnitude;
    }
    private void UpdateProgressFill(float value)
    {
        fillImage.fillAmount = value;
    }
    private void FixedUpdate()
    {
        if (Player != null && JumpPoint != null && Player.transform.position.z < JumpPoint.transform.position.z && GameManager.Instance.isGameStarted)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(GameManager.Instance.gameData.fullDistance, 0f, newDistance);

            UpdateProgressFill(progressValue);
        }
        
    }
}
