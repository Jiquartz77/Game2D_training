using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI_ItemSlot : MonoBehaviour {
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemCount;

    public InventoryItem item;

    void Start() {
    //void UpdateSlot() {
        if (item != null) {
            itemImage.sprite = item.data.itemIcon;
            if (item.stackSize > 1) {
                itemCount.text = item.stackSize.ToString();
            }else{
                itemCount.text = "";
            }
        }
    }
}
