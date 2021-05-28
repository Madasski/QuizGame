using DG.Tweening;
using UnityEngine;

public class TweenPositionBounce : TweenBase
{
    public override void Tween()
    {
        var sequence = DOTween.Sequence();

        var pos = transform.localPosition;
        transform.localPosition += 50 * (Vector3.up + Vector3.left);
        sequence.Append(transform.DOLocalMoveX(0, duration).SetEase(Ease.InBounce))
            .Insert(0, transform.DOLocalMoveY(0, duration).SetEase(Ease.InBounce));
    }
}