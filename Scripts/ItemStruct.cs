using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStruct : MonoBehaviour
{
    public int Id { get; }
    public int Quantity { get; set; }
    public Sprite ItemTexture { get; }

    public ItemStruct(GameObject item, int quantity)
    {
        ItemBase script = item.GetComponent<ItemBase>();
        Id = script.id;
        Quantity = quantity;
        ItemTexture = script.inventoryIcon;
    }
}
