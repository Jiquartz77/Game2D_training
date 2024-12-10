using UnityEngine;

public enum EquippmentType {
	Weapon,
	Armor,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName = "New Equippment", menuName = "Data/Equippment")]
public class Item_Equippment : ItemData {
    public EquippmentType equippmentType;
}
