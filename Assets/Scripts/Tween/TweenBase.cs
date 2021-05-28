using UnityEngine;

public abstract class TweenBase : MonoBehaviour
{
    [SerializeField] protected float duration;
    [SerializeField] private bool tweenOnStart;

    private void Start()
    {
        if (tweenOnStart)
            Tween();
    }

    public abstract void Tween();
}