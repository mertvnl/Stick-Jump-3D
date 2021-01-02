using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(ShowPanel);
        EventManager.OnGameStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }
}
