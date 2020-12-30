using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float loadDelay = 1f;
    private Animator animator;
    public Animator Animator
    {
        get { return (animator == null) ? animator = GetComponent<Animator>() : animator; }
    }

    private void OnEnable()
    {
        EventManager.OnLevelEnd.AddListener(LoadNextLevel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelEnd.RemoveListener(LoadNextLevel);
    }

    [Button]
    public void LoadNextLevel()
    {
        if (GameManager.Instance.isGameStarted)
        {
            StartCoroutine(LoadLevelCo());
        }
    }


    private IEnumerator LoadLevelCo()
    {
        Animator.SetTrigger("Start");
        yield return new WaitForSeconds(loadDelay);

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        //If next level can't be loaded then load level 1.
        if (!Application.CanStreamedLevelBeLoaded(nextLevel))
        {
            yield return SceneManager.UnloadSceneAsync(currentLevel);
            yield return SceneManager.LoadSceneAsync(("Level01"), LoadSceneMode.Additive);
            Scene loadedScene = SceneManager.GetSceneByName("Level01");
            SceneManager.SetActiveScene(loadedScene);
        }
        //If next level can be loaded then load next level.
        else
        {
            yield return SceneManager.UnloadSceneAsync(currentLevel);
            yield return SceneManager.LoadSceneAsync((nextLevel), LoadSceneMode.Additive);
            Scene loadedScene = SceneManager.GetSceneByBuildIndex(nextLevel);
            SceneManager.SetActiveScene(loadedScene);
        }
        EventManager.OnLevelChange.Invoke();
        Animator.SetTrigger("End");
    }
    
}
