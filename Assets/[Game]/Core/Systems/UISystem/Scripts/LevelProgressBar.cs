using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressBar : Panel
{
    private CanvasGroup canvasGroup;

    public CanvasGroup CanvasGroup
    {
        get
        {
            if (canvasGroup==null)
            {
                canvasGroup = GetComponentInParent<CanvasGroup>();
            }

            return canvasGroup;
        }
    }
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(ShowPanel);
    }
    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(ShowPanel);
    }
}
