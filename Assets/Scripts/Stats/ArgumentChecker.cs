using System;

public class ArgumentChecker
{
    public bool CheckPositiveValue(float valueToCheck)
    {
        if (valueToCheck < 0)
            throw new ArgumentOutOfRangeException(nameof(valueToCheck));

        return true;
    }

    public bool CheckRange(float value, float addableValue, float maxValue)
    {
        return value + addableValue > maxValue;
    }
}