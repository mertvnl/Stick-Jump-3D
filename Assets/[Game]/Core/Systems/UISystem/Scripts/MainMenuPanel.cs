using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(HidePanel);
    }
}
