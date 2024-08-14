using UnityEngine;

public abstract class StatView : MonoBehaviour
{
    protected IRangeable Stat { get; private set; }

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

    public virtual void Initialize(IRangeable stat)
    {
        Stat = stat;
        Stat.ValueChanged += SetValue;

        SetValue();
    }

    protected abstract void SetValue();
}