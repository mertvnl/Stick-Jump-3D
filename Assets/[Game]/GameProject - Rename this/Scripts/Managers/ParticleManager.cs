using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
    public GameObject confettiPrefab;
    private void OnEnable()
    {
        EventManager.OnLevelEnd.AddListener(PlayConfetti);
    }

    private void OnDisable()
    {
        EventManager.OnLevelEnd.RemoveListener(PlayConfetti);
    }

    [Button]
    void PlayConfetti()
    {
        Instantiate(confettiPrefab, PlayerMovement.Instance.transform.position, Quaternion.identity);
    }
}
