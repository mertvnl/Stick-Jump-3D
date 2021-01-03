using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text scorePanelText;

    public Text ScorePanelText
    {
        get
        {
            if (scorePanelText == null)
            {
                scorePanelText = GetComponent<Text>();
            }

            return scorePanelText;
        }
    }
    private void FixedUpdate()
    {
        ScorePanelText.text = GameManager.Instance.gameData.score.ToString();
    }
}
