using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickColor 
{
    public Color color;
    public enum Color
{
    Red,
    Green,
    Blue,
    Yellow,
    Null
}
    public PickColor()
    {
        this.color = Color.Null;
    }    
}

