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
        StartCoroutine(PlayConfettiCo());
    }

    IEnumerator PlayConfettiCo()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(confettiPrefab, PlayerMovement.Instance.transform.position + Vector3.up, Quaternion.identity);
    }
}
