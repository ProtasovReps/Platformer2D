using System;

public interface IRangeable
{
    public float MaxValue { get; }
    public float Value { get; }

    public event Action ValueChanged;
}
