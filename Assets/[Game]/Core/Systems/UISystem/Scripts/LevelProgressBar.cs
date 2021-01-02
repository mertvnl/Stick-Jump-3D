using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressBar : Panel
{
    private CanvasGroup canvasGroupPanel;

    public CanvasGroup CanvasGroupPanel
    {
        get
        {
            if (canvasGroupPanel==null)
            {
                canvasGroupPanel = GetComponentInParent<CanvasGroup>();
            }

            return canvasGroupPanel;
        }
    }
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(ShowPanel);
        // EventManager.OnLevelStart.AddListener(ShowPanel);
    }
    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(ShowPanel);
        // EventManager.OnLevelStart.RemoveListener(ShowPanel);
    }
}
