using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    [FormerlySerializedAs("GameData")] [InlineEditor(InlineEditorModes.GUIOnly)]
    public GameData gameData;

    public bool isGameStarted = false;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(() => isGameStarted = true);
        EventManager.OnGameStart.AddListener(()=> gameData.score = 0);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(() => isGameStarted = true);
        EventManager.OnGameStart.RemoveListener(()=> gameData.score = 0);
    }

    private void Start()
    {
        if (gameData == null)
        {
            Debug.LogError("GameData is not set, please set the game data");
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Invoke OnGameStart event when a new level is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EventManager.OnGameStart.Invoke();
    }
}
