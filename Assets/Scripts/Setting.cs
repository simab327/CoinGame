using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : object
{
    public static int ForceValue = 1;
    public static int WeightValue = 1;

    public static void SetValue(string Name, int Value)
    {
        if (Name == "Force")
        {
            ForceValue = Value;
        }

        if (Name == "Weight")
        {
            WeightValue = Value;
        }

        Debug.Log("Set Value Name: " + Name + ", Value: " + Value);
    }

    public static int GetValue(string Name)
    {
        int value = 99;
        if (Name == "Force")
        {
            value = ForceValue;
        }

        if (Name == "Weight")
        {
            value = WeightValue;
        }
        return value;
    }
}
