using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<CellDataSetSO> cellDataSets;
    [SerializeField] private LevelDataSO[] levels;

    private List<Cell> cells = new List<Cell>();
    private List<Cell> ActiveCells => cells.Where(cell => cell.gameObject.activeInHierarchy).ToList();
    private List<CellData>[] possibleCorrectCellData;
    private int currentLevelIndex = -1;
    private CellData correctCellData;
    private Cell correctCell;

    public List<Cell> Cells => cells;
    public Cell CorrectCell => correctCell;
    public bool IsCurrentLevelTheLast => currentLevelIndex == levels.Length - 1;

    public UnityEvent<string> LevelStarted;

    public void Init()
    {
        cells = GetComponent<CellSpawner>().SpawnCells();
        foreach (var cell in cells)
        {
            cell.Image.preserveAspect = true;
        }

        if (possibleCorrectCellData == null)
        {
            var numberOfDataSets = cellDataSets.Count;
            possibleCorrectCellData = new List<CellData>[numberOfDataSets];

            for (int i = 0; i < numberOfDataSets; i++)
            {
                possibleCorrectCellData[i] = cellDataSets[i].CellData.ToList();
            }
        }
    }

    public void StartLevelWithRandomCellDataSet()
    {
        currentLevelIndex++;
        if (currentLevelIndex == levels.Length) currentLevelIndex = 0;

        ActivateRequiredCells(levels[currentLevelIndex].numberOfCells);
        PopulateCells(cellDataSets[Random.Range(0, cellDataSets.Count)]);

        LevelStarted.Invoke(correctCellData.Name);
    }

    private void PopulateCells(CellDataSetSO dataSet)
    {
        var possibleCorrectCellDataForCurrentDataSet = possibleCorrectCellData[cellDataSets.IndexOf(dataSet)];
        if (possibleCorrectCellDataForCurrentDataSet.Count <= 0)
        {
            Debug.LogError("There are no more options for correct answer for " + dataSet.name + " dataset");
            return;
        }

        correctCellData = possibleCorrectCellDataForCurrentDataSet[Random.Range(0, possibleCorrectCellDataForCurrentDataSet.Count)];
        possibleCorrectCellDataForCurrentDataSet.Remove(correctCellData);

        var cellsData = dataSet.CellData;
        var cellsDataExceptCorrect = cellsData.ToList();
        cellsDataExceptCorrect.Remove(correctCellData);

        var correctAnswerIndex = Random.Range(0, ActiveCells.Count);

        for (var i = 0; i < ActiveCells.Count; i++)
        {
            var activeCell = ActiveCells[i];
            CellData cellData;

            if (i != correctAnswerIndex)
            {
                cellData = cellsDataExceptCorrect[Random.Range(0, cellsDataExceptCorrect.Count)];
            }
            else
            {
                cellData = correctCellData;
                correctCell = activeCell;
            }

            activeCell.Image.sprite = cellData.Sprite;
            activeCell.Image.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -cellData.SpriteRotationClockwise));
        }
    }

    private void ActivateRequiredCells(int amount)
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].gameObject.SetActive(i < amount);
        }
    }
}