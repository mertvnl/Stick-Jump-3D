using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelPanel : Panel
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
        CurrentLevelText.text = "LEVEL " + LevelManager.Instance.currentLevelIndex;
    }

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(UpdateUI);
        EventManager.OnGameStart.AddListener(ShowPanelAndTurnOffInteraction);
        EventManager.OnLevelChange.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(UpdateUI);
        EventManager.OnGameStart.RemoveListener(ShowPanelAndTurnOffInteraction);
        EventManager.OnLevelChange.RemoveListener(UpdateUI);
    }

    public void UpdateUI()
    {
        CurrentLevelText.text = "LEVEL " + LevelManager.Instance.currentLevelIndex;
    }
}
