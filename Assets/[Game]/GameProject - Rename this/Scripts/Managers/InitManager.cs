using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync((1), LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync((2), LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(2));
        Destroy(gameObject);
    }
}