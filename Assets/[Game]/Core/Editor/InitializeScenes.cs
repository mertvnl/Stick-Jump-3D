// using UnityEditor;
// using UnityEngine.SceneManagement;
//
//
// [InitializeOnLoad]
//
// public static class InitializeScenes
// {
//     // register an event handler when the class is initialized
//
//     static InitializeScenes()
//
//     {
//         EditorApplication.playModeStateChanged += LogPlayModeState;
//
//     }
//
//     private static void LogPlayModeState(PlayModeStateChange state)
//     {
//         bool hasInit = false;
//
//
//         if (PlayModeStateChange.EnteredPlayMode == state)
//         {
//             int sceneCount = SceneManager.sceneCount;
//
//             for (int i = 0; i < sceneCount; i++)
//             {
//
//                 if (SceneManager.GetSceneAt(i).buildIndex == 0)
//                 {
//                     hasInit = true;
//
//                 }
//             }
//             if (!hasInit)
//             {
//                 SceneManager.LoadScene(0);
//             }
//         }
//     }
// }