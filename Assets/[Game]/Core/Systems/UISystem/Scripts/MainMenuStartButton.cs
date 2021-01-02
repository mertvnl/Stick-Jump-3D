using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuStartButton : Panel
{
    public void StartGame()
    {
        EventManager.OnLevelStart.Invoke();
    }
}
