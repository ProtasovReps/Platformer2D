using TMPro;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Collector _collector;

    public void Initialize()
    {
        _collector.AmountChanged += DisplayCollectorValue;
        DisplayCollectorValue();
    }

    private void OnDisable()
    {
        _collector.AmountChanged -= DisplayCollectorValue;
    }

    private void DisplayCollectorValue()
    {
        _text.text = _collector.Value.ToString();
    }
}
