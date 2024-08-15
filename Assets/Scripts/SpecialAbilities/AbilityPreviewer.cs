using UnityEngine;

public class VampirismRangePreview : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rangePreview;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private EnemyCapsuleSearcher _enemyCapsuleSearcher;
    [SerializeField] private Color _notFoundColor;
    [SerializeField] private Color _foundColor;

    private void OnEnable()
    {
        _enemyCapsuleSearcher.Found += SetColor;
        _vampirism.Started += Show;
        _vampirism.Ended += Hide;
    }

    private void OnDisable()
    {
        _enemyCapsuleSearcher.Found -= SetColor;
        _vampirism.Started -= Show;
        _vampirism.Ended -= Hide;
    }

    private void SetColor(bool isFound)
    {
        if (isFound)
            _rangePreview.color = _foundColor;
        else
            _rangePreview.color = _notFoundColor;
    }

    private void Show() => _rangePreview.enabled = true;

    private void Hide() => _rangePreview.enabled = false;
}
