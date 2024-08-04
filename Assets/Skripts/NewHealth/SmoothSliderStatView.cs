using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderStatView : StatView
{
    [SerializeField] private Slider _slider;
    [SerializeField, Range(0.002f, 0.01f)] private float _valueChangeSpeed;

    private Coroutine _coroutine;

    protected override void SetValue()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(SetSliderValueSmoothly());
    }

    private IEnumerator SetSliderValueSmoothly()
    {
        float valueChangeSpeed = _slider.maxValue * _valueChangeSpeed;

        while (_slider.value != GetNewSliderValue())
        {
            _slider.value = Mathf.MoveTowards(_slider.value, GetNewSliderValue(), valueChangeSpeed);
            yield return null;
        }

        _coroutine = null;
    }

    private float GetNewSliderValue()
    {
        float healthRatio = (float)Stat.GetValue() / Stat.GetMaxValue();
        float newSliderValue = _slider.maxValue * healthRatio;

        return newSliderValue;
    }
}
