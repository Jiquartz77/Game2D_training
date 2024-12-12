using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSlot : MonoBehaviour, IPointerDownHandler {
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemCount;

    public InventoryItem item;

    public void UpdateSlot(InventoryItem _item) {

        if (_item != null) {

            item = _item; // the last item

            itemImage.color = Color.white; //not transparent
            itemImage.sprite = _item.data.itemIcon;

            if (_item.stackSize >= 1) {
                itemCount.text = _item.stackSize.ToString();
            }else{
                itemCount.text = "";
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Clicked" + item.data.itemName );
        if (item.data.itemType == ItemType.Equippment){
            Inventory.instance.EquipItem(item.data);
        }
    }
}
