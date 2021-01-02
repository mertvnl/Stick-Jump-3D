using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnLevelEnd.AddListener(ShowPanel);
        EventManager.OnGameStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelEnd.RemoveListener(ShowPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }
}
