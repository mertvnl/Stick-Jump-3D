using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelContinue = new UnityEvent();
    public static UnityEvent OnLevelEnd = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnLevelChange = new UnityEvent();
}
