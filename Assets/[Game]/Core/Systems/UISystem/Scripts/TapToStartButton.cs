using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TapToStartButton : Panel
{
    public void StartGame()
    {
        EventManager.OnLevelStart.Invoke();
    }
}
