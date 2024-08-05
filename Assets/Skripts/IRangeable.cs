using System;

public interface IRangeable
{
    public int MaxValue { get; }
    public int Value { get; }

    public event Action ValueChanged;
}
