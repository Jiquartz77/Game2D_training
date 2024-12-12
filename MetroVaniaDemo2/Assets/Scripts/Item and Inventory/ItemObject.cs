using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour {
    private SpriteRenderer sr;
    [SerializeField] private ItemData itemData;

    private void OnValidate() {
        GetComponent<SpriteRenderer>().sprite = itemData.itemIcon;
        gameObject.name = "ItemObject - " + itemData.itemName;
        
    }
    private void Start() {
        //sr = GetComponent<SpriteRenderer>();
        //sr.sprite = itemData.itemIcon;
    }

    private  void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Player>() != null){
            Inventory.instance.AddItem(itemData);
            Destroy(gameObject);
        }
    }
}