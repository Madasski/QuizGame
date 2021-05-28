using DG.Tweening;
using UnityEngine.UI;

public class TweenImageTransparencyFade : TweenBase
{
    public override void Tween()
    {
        var image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
        image.DOFade(1, duration);
    }
}