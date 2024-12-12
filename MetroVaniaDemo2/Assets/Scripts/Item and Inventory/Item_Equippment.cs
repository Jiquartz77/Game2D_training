using UnityEngine;

public enum EquipmentType {
	Weapon,
	Armor,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName = "New Equippment", menuName = "Data/Equippment")]
public class Item_Equipment : ItemData {
    public EquipmentType equippmentType;
}
