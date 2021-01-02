using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelButtons : MonoBehaviour
{
    public void NextLevelButton()
    {
        LevelLoader.Instance.LoadNextLevel();
    }
}
