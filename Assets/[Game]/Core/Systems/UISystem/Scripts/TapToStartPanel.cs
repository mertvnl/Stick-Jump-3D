using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartPanel : Panel
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
