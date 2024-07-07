using System;
using UnityEngine;

public abstract class Collector : MonoBehaviour 
{
    public int Value {  get; protected set; }

    public abstract event Action AmountChanged;

    public abstract void Collect(int value);
}