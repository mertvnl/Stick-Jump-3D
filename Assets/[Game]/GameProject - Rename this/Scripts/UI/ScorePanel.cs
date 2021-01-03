using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }

    private void FixedUpdate()
    {
        if (PlayerMovement.Instance != null)
        {
            if (PlayerMovement.Instance.canScore)
            {
                ShowPanelAndTurnOffInteraction();
            }
        }
    }
}
