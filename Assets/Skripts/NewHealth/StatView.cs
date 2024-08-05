using UnityEngine;

public abstract class StatView : MonoBehaviour
{
    protected IRangeable Stat { get; private set; }

    private void OnEnable()
    {
        if (Stat != null)
            Stat.ValueChanged += StartSettingValue;
    }

    private void OnDisable()
    {
        if (Stat != null)
            Stat.ValueChanged -= StartSettingValue;
    }

    public void Initialize(IRangeable stat)
    {
        Stat = stat;
        Stat.ValueChanged += StartSettingValue;

        StartSettingValue();
    }

    protected abstract void StartSettingValue();
}