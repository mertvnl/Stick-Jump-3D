using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UnityToolbarExtender.Examples
{
	static class ToolbarStyles
	{
		public static readonly GUIStyle commandButtonStyle;

		static ToolbarStyles()
		{
			commandButtonStyle = new GUIStyle("Command")
			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageAbove,
				fontStyle = FontStyle.Bold
			};
		}
	}

	[InitializeOnLoad]
	public class SceneSwitchLeftButton
	{
		static SceneSwitchLeftButton()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

			if(GUILayout.Button(new GUIContent("0", "Init scene"), ToolbarStyles.commandButtonStyle))
			{
				EditorSceneManager.OpenScene(EditorBuildSettings.scenes[0].path);
			}

			if(GUILayout.Button(new GUIContent("1", "UI scene"), ToolbarStyles.commandButtonStyle))
			{
				EditorSceneManager.OpenScene(EditorBuildSettings.scenes[1].path);
			}
			
			if(GUILayout.Button(new GUIContent("2", "Level 01 scene"), ToolbarStyles.commandButtonStyle))
			{
				EditorSceneManager.OpenScene(EditorBuildSettings.scenes[2].path);
			}
		}
	}
}