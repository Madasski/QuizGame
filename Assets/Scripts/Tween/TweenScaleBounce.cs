using DG.Tweening;

public class TweenScaleBounce : TweenBase
{
    public override void Tween()
    {
        var originalScale = transform.localScale;
        transform.localScale = originalScale * 0.6f;

        transform.DOScale(originalScale, duration).SetEase(Ease.OutElastic);
    }
}