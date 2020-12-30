using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }
}
