using System;

public interface IValueShareable
{
    public event Action ValueChanged;

    public int GetValue();

    public int GetMaxValue();
}
