using UnityEngine;

public abstract class StatView : MonoBehaviour
{
    protected IValueShareable Stat { get; private set; }

    private void OnEnable()
    {
        if (Stat != null)
            Stat.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        if (Stat != null)
            Stat.ValueChanged -= SetValue;
    }

    public void Initialize(IValueShareable stat)
    {
        Stat = stat;
        Stat.ValueChanged += SetValue;

        SetValue();
    }

    protected abstract void SetValue();
}