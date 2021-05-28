using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelDataScriptableObject", order = 1)]
public class LevelDataSO : ScriptableObject
{
    [Range(1, 9)] public int numberOfCells;
}