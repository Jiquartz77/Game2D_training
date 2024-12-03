using System;
using UnityEngine;
using UnityEngine.Android;

[Serializable]

public class InventoryItem : MonoBehaviour {
    public ItemData data;
    public int stackSize;

    public InventoryItem(ItemData data) {
        this.data = data;
        stackSize = 1;
    }

    public void AddStack() => stackSize++;
    public void RemoveStack() => stackSize--;
}
