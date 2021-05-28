using DG.Tweening;
using UnityEngine.UI;

public class TweenTextTransparencyFade : TweenBase
{
    public override void Tween()
    {
        var text = GetComponent<Text>();
        var tempColor = text.color;
        tempColor.a = 0;
        text.color = tempColor;
        text.DOFade(1, duration);
    }
}