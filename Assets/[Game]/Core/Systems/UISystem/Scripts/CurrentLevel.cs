using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour
{
    private Text currentLevelText;

    public Text CurrentLevelText
    {
        get
        {
            if (currentLevelText == null)
            {
                currentLevelText = GetComponentInChildren<Text>();
            }
            return currentLevelText;
        }
    }

    private void Start()
    {
        CurrentLevelText.text = LevelManager.Instance.currentLevelIndex.ToString();
    }

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(UpdateUI);
        EventManager.OnLevelChange.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(UpdateUI);
        EventManager.OnLevelChange.RemoveListener(UpdateUI);
    }


    public void UpdateUI()
    {
        CurrentLevelText.text = LevelManager.Instance.currentLevelIndex.ToString();
    }
}
