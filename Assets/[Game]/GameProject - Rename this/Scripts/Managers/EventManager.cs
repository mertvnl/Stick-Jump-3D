using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent(); //açık panelleri kapat
    public static UnityEvent OnGameEnd = new UnityEvent();
    
    public static UnityEvent OnLevelStart = new UnityEvent(); // playeri control et, koş,  progress bar aç 
    public static UnityEvent OnLevelContinue = new UnityEvent();
    public static UnityEvent OnLevelEnd = new UnityEvent(); // playeri controllerini kapat, koşma, dans et, konfeti at, win panel aç - kazanınca invoke
    public static UnityEvent OnLevelFail = new UnityEvent(); // playeri controllerini kapat, koşma, ölme efekti, ölüm paneli aç - ölünce invoke
    public static UnityEvent OnLevelChange = new UnityEvent(); // tap to start aç
}
