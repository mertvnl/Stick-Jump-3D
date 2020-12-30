using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBarText : MonoBehaviour
{
    private Text levelPercentage;

    public Text LevelPercentage
    {
        get
        {
            if (levelPercentage == null)
            {
                levelPercentage = GetComponent<Text>();
            }

            return levelPercentage;
        }
    }

    private Slider progressBar;

    public Slider ProgressBar
    {
        get
        {
            if (progressBar == null)
            {
                progressBar = GetComponentInParent<Slider>();
            }

            return progressBar;
        }
    }

    private void Update()
    {
        LevelPercentage.text = ProgressBar.value + "%";
    }
}
