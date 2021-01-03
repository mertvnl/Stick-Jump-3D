using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
    public GameObject confettiPrefab;
    public GameObject stickCollectPrefab;
    public GameObject stickCutEffectPrefab;
    public GameObject playerJumpEffectPrefab;
    public GameObject speedEffectPrefab;
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

    public void PlayStickCollect()
    {
        Instantiate(stickCollectPrefab, PlayerMovement.Instance.transform.position + Vector3.right,
            Quaternion.identity, PlayerMovement.Instance.transform);
    }

    public void PlayStickCutEffect()
    {
        StartCoroutine(PlayStickCutEffectCo());
    }

    IEnumerator PlayStickCutEffectCo()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(stickCutEffectPrefab, StickTop.Instance.transform.position + Vector3.back, Quaternion.identity);
    }

    public void PlayPlayerJumpEffect()
    {
        Instantiate(playerJumpEffectPrefab, PlayerMovement.Instance.transform.position, Quaternion.identity);
    }

    // public void PlaySpeedEffect()
    // {
    //     StartCoroutine(PlaySpeedEffectCo());
    // }
    //
    // IEnumerator PlaySpeedEffectCo()
    // {
    //     yield return new WaitForSeconds(1.5f);
    //     Instantiate(speedEffectPrefab, Camera.main.transform.position, new Quaternion(-103f, 0, 90, Quaternion.identity.w), Camera.main.transform);
    // }
}
