using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image image;

    public Button Button { get; private set; }

    public UnityEvent<Cell> Pressed;
    public UnityEvent OnWrong;

    public Image Image
    {
        get
        {
            if (!image)
            {
                Debug.LogError("There is no image component in cell");
            }

            return image;
        }
        set => Image = value;
    }

    private void Awake()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(Clicked);
    }

    private void OnDestroy()
    {
        Button.onClick.RemoveListener(Clicked);
        Pressed.RemoveAllListeners();
    }

    private void Clicked()
    {
        Pressed?.Invoke(this);
    }

    public void Wrong()
    {
        OnWrong?.Invoke();
    }
}