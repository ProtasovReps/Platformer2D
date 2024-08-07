using System.Collections;
using TMPro;
using UnityEngine;

public class SmoothTextStatView : StatView
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _fontSizeEnhanceValue;
    [SerializeField] private int _valueChangeSpeed = 1; 

    private int _lastValue;
    private Coroutine _coroutine;

    protected override void StartSettingValue()
    {
        if(_coroutine == null)
            _coroutine = StartCoroutine(SetValueSmoothly());
    }

    private IEnumerator SetValueSmoothly()
    {
        _text.fontSize += _fontSizeEnhanceValue;

        while(_lastValue != Stat.Value)
        {
            _lastValue = (int)Mathf.MoveTowards(_lastValue, Stat.Value, _valueChangeSpeed);
            _text.text = _lastValue.ToString();
            yield return null;
        }

        _text.fontSize -= _fontSizeEnhanceValue;
        _coroutine = null;
    }
}
