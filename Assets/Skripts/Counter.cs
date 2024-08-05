using System;

public class Counter : IRangeable
{
    public event Action ValueChanged;

    public int MaxValue => Value;

    public int Value { get; private set; }

    public void Increase()
    {
        Value++;
        ValueChanged?.Invoke();
    }
}
