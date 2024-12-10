using System.Text;
using UnityEngine;

public enum ItemType {
    Material,
    Equippment
}

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Item")]
public class ItemData : ScriptableObject {
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
}
