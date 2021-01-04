using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmojiManager : MonoBehaviour
{

    public List<GameObject> emojis = new List<GameObject>();

    
    private void OnEnable()
    {
        EventManager.OnLevelEnd.AddListener(SelectEmoji);
        EventManager.OnLevelFail.AddListener(SelectEmoji);
    }

    private void OnDisable()
    {
        EventManager.OnLevelEnd.RemoveListener(SelectEmoji);
        EventManager.OnLevelFail.RemoveListener(SelectEmoji);
    }
    [Button]
    public void SelectEmoji()
    {
        int randomEmoji = Random.Range(0, emojis.Count);
        int count = emojis.Count;
        for (int i = 0; i < count; i++)
        {
            emojis[i].SetActive(false);
        }
        
        emojis[randomEmoji].SetActive(true);
    }
}
