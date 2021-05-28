using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "CellDataSet", menuName = "ScriptableObjects/CellDataSetScriptableObject", order = 1)]
public class CellDataSetSO : ScriptableObject
{
    [SerializeField] private CellData[] cellData;

    public CellData[] CellData
    {
        get => cellData;
        private set => cellData = value;
    }
}