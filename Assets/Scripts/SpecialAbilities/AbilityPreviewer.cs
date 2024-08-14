using UnityEngine;

public class AbilityPreview : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rangePreview;
    [SerializeField] private Timer _timer;
    [SerializeField] private Color _disabledColor;
    [SerializeField] private Color _enabledColor;

    public void ShowAbilityRange()
    {
        if (_timer.IsEnded)
            _rangePreview.color = _enabledColor;
        else
            _rangePreview.color = _disabledColor;
        
        _rangePreview.enabled = true;
    }

    public void HideAbilityRange() => _rangePreview.enabled = false;
}
