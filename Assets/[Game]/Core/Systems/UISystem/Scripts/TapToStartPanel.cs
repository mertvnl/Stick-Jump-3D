using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(ShowPanel);
        EventManager.OnLevelStart.RemoveListener(HidePanel);
    }
}
