using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private string mainTextPart;

    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        levelController.LevelStarted.AddListener(UpdateObjective);
    }

    public void UpdateObjective(string text)
    {
        this.textComponent.text = mainTextPart + " " + text;
    }
}