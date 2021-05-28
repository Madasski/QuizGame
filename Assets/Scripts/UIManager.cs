using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject RestartScreen;
    [SerializeField] private GameObject Objective;
    // [SerializeField] private GameObject RestartScreen;

    public void ShowRestartScreen()
    {
        RestartScreen.SetActive(true);
    }
    
    public void HideRestartScreen()
    {
        RestartScreen.SetActive(false);
    }
    
    public void ShowObjective()
    {
        Objective.SetActive(true);
    }
    
    
    
}