using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory instance;

    public List<InventoryItem> listInv;
    public Dictionary<ItemData, InventoryItem> dictInv;

    public List<InventoryItem> listStash;
    public Dictionary<ItemData, InventoryItem> dictStash;

    public List<InventoryItem> listEquipment;
    public Dictionary<Item_Equipment, InventoryItem> dictEquipment;

    [SerializeField] private Transform inventorySlotParent;
    [SerializeField] private Transform stashSlotParent;

    private UI_ItemSlot[] itemSlots;
    private UI_ItemSlot[] stashSlots;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }else {
            Destroy(instance);
        }
    }

    private void Start() {
        listInv = new List<InventoryItem>();
        dictInv = new Dictionary<ItemData, InventoryItem>();

        listStash = new List<InventoryItem>();
        dictStash = new Dictionary<ItemData, InventoryItem>();

        listEquipment = new List<InventoryItem>();
        dictEquipment = new Dictionary<Item_Equipment, InventoryItem>();

        itemSlots = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
        stashSlots = stashSlotParent.GetComponentsInChildren<UI_ItemSlot>();
    }

    private void UpdateSlotUI(){
        for (int i = 0; i < listInv.Count; i++) { itemSlots[i].UpdateSlot(listInv[i]); }
        for (int i = 0; i < listStash.Count; i++) { stashSlots[i].UpdateSlot(listStash[i]); }
    }

    public void EquipItem(ItemData item) {
        Item_Equipment equippment = item as Item_Equipment;
        InventoryItem newItem = new InventoryItem(item);
        Item_Equipment oldEquip =null;

        foreach(KeyValuePair<Item_Equipment, InventoryItem> kvp in dictEquipment){
            if (kvp.Key.equippmentType == equippment.equippmentType) {
                oldEquip = kvp.Key;
            }
        }

        if (oldEquip != null) {
            UnequipItem(oldEquip);
            AddItem(oldEquip);
        }

        listEquipment.Add(newItem);
        dictEquipment.Add(equippment, newItem);
        RemoveItem(item); //remove from inventory

        UpdateSlotUI();
    }

    public void UnequipItem(ItemData item) {
    }

    public void AddItem(ItemData item) {
        if (item.itemType == ItemType.Equippment) {
            AddToInv(item);
        }else if (item.itemType == ItemType.Material) {
            AddToStash(item);
        }

        UpdateSlotUI();
    }

    private void AddToStash(ItemData item)
    {
        if (dictStash.TryGetValue(item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            listStash.Add(newItem);
            dictStash.Add(item, newItem);
        }
    }

    private void AddToInv(ItemData item)
    {
        if (dictInv.TryGetValue(item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            listInv.Add(newItem);
            dictInv.Add(item, newItem);
        }
    }

    public void RemoveItem(ItemData item) {
        if (dictStash.TryGetValue(item, out InventoryItem value)) {
            if (value.stackSize <= 1) {
                listInv.Remove(value);
                dictStash.Remove(item);
            }
            else {
                value.RemoveStack();
            }
        }
        UpdateSlotUI();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log(listInv[listInv.Count-1].data.itemName);
            ItemData drop = listInv[listInv.Count-1].data;
            RemoveItem(drop);
        }
    }
    
}
