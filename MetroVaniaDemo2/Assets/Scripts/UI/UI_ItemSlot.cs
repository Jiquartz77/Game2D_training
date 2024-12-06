using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI_ItemSlot : MonoBehaviour {
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemCount;

    public InventoryItem item;

    public void UpdateSlot(InventoryItem _item) {
        if (_item != null) {
            itemImage.sprite = _item.data.itemIcon;
            if (_item.stackSize >= 1) {
                itemCount.text = _item.stackSize.ToString();
            }else{
                itemCount.text = "";
            }
        }
    }
}
