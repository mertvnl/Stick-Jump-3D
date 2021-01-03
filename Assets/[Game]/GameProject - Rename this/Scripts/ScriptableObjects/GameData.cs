using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [Header("Example Object Data")]
    public List<GameObject> exObjectsToCreate = new List<GameObject>();
    
    [Header("Example Track Data")]
    public List<GameObject> exTracksToCreate = new List<GameObject>();
    
    [Header("Example Obstacle Data")]
    public List<GameObject> exObstaclesToCreate = new List<GameObject>();

    [Header("Level Data")]
    [Range(0,1000)]
    public float levelSpeed;
    [Range(0,100)]
    public float levelSpeedMultiplier;

    [Header("Joystick Data")] public Joystick currentJoystick;
    
    [ReadOnly]
    public float fallingStickSizeY;

    public float fullDistance;

    public GameObject currentPlayer;
    public GameObject currentJumpPoint;

    public int score;

}