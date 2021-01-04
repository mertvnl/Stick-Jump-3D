using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    public float loadDelay = 1f;
    private Animator animator;
    public Animator Animator
    {
        get { return (animator == null) ? animator = GetComponent<Animator>() : animator; }
    }


    [Button]
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelCo());
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
            LevelManager.Instance.ResetLevelData();
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
    
    [Button]
    public void LoadCurrentLevel()
    {
        StartCoroutine(LoadCurrentLevelCo());
    }


    private IEnumerator LoadCurrentLevelCo()
    {
        Animator.SetTrigger("Start");
        yield return new WaitForSeconds(loadDelay);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        yield return SceneManager.UnloadSceneAsync(currentLevel);
        yield return SceneManager.LoadSceneAsync((currentLevel), LoadSceneMode.Additive);
        Scene loadedScene = SceneManager.GetSceneByBuildIndex(currentLevel);
        SceneManager.SetActiveScene(loadedScene);
        Animator.SetTrigger("End");
    }
    
}
