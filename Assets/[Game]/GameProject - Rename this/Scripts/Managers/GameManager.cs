using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    [FormerlySerializedAs("GameData")] [InlineEditor(InlineEditorModes.GUIOnly)]
    public GameData gameData;

    public bool isGameStarted = false;

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(() => isGameStarted = true);
    }
    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(() => isGameStarted = true);
    }

    private void Start()
    {
        if (gameData == null)
        {
            Debug.LogError("GameData is not set, please set the game data");
        }
    }
}
