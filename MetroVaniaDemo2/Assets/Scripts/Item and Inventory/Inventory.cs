using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory instance;
    public List<InventoryItem> inventoryList;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }else {
            Destroy(instance);
        }
    }

    private void Start() {
        inventoryList = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<ItemData, InventoryItem>();
    }

    public void AddItem(ItemData item) {
        if (inventoryDictionary.TryGetValue(item, out InventoryItem value) ){
            value.AddStack();
        }else{
            InventoryItem newItem = new InventoryItem(item);
            inventoryList.Add(newItem);
            inventoryDictionary.Add(item, newItem);
        }
    }

    public void RemoveItem(ItemData item) {
        if (inventoryDictionary.TryGetValue(item, out InventoryItem value) ){
            if (value.stackSize <=1){
                inventoryList.Remove(value);
                inventoryDictionary.Remove(item);
            }
        else{
            value.RemoveStack();
        }
        }
    }
    
}
