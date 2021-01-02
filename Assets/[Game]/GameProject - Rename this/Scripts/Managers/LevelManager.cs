using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevelIndex;
    public int nextLevelIndex;

    private void Awake()
    {
        InitializeLevelData();
    }

    [Button]
    public void ResetLevelData()
    {
        PlayerPrefs.DeleteKey("CurrentLevelIndex");
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        nextLevelIndex = currentLevelIndex + 1;
    }
    
    [Button]
    public void LoadNextLevel()
    {
        LevelLoader.Instance.LoadNextLevel();
    }
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(InitializeLevelData);
        EventManager.OnLevelEnd.AddListener(UpdateLevelData);
        EventManager.OnLevelChange.AddListener(InitializeLevelData);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(InitializeLevelData);
        EventManager.OnLevelEnd.RemoveListener(UpdateLevelData);
        EventManager.OnLevelChange.RemoveListener(InitializeLevelData);
    }

    public void UpdateLevelData()
    {
        if (GameManager.Instance.isGameStarted)
        {
            currentLevelIndex++;
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex);
            nextLevelIndex = currentLevelIndex + 1;
        }
    }

    public void InitializeLevelData()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        nextLevelIndex = currentLevelIndex + 1;
    }
}
