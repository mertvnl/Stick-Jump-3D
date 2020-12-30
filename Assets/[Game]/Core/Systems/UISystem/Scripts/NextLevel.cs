using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    private Text nextLevelText;

    public Text NextLevelText
    {
        get
        {
            if (nextLevelText == null)
            {
                nextLevelText = GetComponentInChildren<Text>();
            }
            return nextLevelText;
        }
    }

    private void Start()
    {
        NextLevelText.text = LevelManager.Instance.nextLevelIndex.ToString();
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
        NextLevelText.text = LevelManager.Instance.nextLevelIndex.ToString();
    }
}
