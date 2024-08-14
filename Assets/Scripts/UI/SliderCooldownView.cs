using UnityEngine;
using UnityEngine.UI;

public class SliderCooldownView : StatView
{
    [SerializeField] private Slider _slider;

    public override void Initialize(IRangeable stat)
    {
        base.Initialize(stat);
        _slider.value = _slider.maxValue;
    }

    protected override void SetValue()
    {
        _slider.value = _slider.maxValue * Stat.Value;
    }
}
