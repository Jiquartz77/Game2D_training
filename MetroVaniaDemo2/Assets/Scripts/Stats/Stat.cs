using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {
    //private int baseValue;
    [SerializeField] private int baseValue;
    public List<int> modifiers;

    public int GetValue() {
        int finalValue = baseValue;

        foreach (int m in modifiers){
            finalValue += m;
        }

        return finalValue;
    }

    public void SetDefaultValue(int _baseValue) {
        baseValue = _baseValue;
    }

    public void AddModifier(int _modifier) {
        modifiers.Add(_modifier);
    }

    public void RemoveModifier(int _modifier) {
        modifiers.Remove(_modifier);
    }
}