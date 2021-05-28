using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private LevelController levelController;

    public UnityEvent GameEndReached;
    public UnityEvent GameStarted;

    private void Awake()
    {
        levelController = GetComponent<LevelController>();
    }

    private void Start()
    {
        StartNewGame();
    }

    private void OnCellPress(Cell cell)
    {
        if (cell == levelController.CorrectCell)
        {
            if (levelController.IsCurrentLevelTheLast)
            {
                GameEndReached?.Invoke();
            }
            else
            {
                levelController.StartLevelWithRandomCellDataSet();
            }
        }
        else
        {
            cell.Wrong();
        }
    }

    public void StartNewGame()
    {
        levelController.Init();
        foreach (var cell in levelController.Cells)
        {
            cell.Pressed.AddListener(OnCellPress);
        }

        GameStarted?.Invoke();
        levelController.StartLevelWithRandomCellDataSet();
    }
}