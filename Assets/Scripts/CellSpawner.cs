using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private GameObject cellsGO;
    private List<Cell> cells;

    public List<Cell> SpawnCells()
    {
        if (cells !=null&&cells.Count > 0)
        {
            RemoveOldCells();
        }


        cells = new List<Cell>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var cell = Instantiate(cellPrefab, cellsGO.transform, false);
                cells.Add(cell);
            }
        }

        return cells;
    }

    private void RemoveOldCells()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            Destroy(cells[i].gameObject);
        }
    }
}