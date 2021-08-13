using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{ 
    Canvas inventoryUi;
    PlayerMovement playerMovementScript;
    PlayerAttack playerAttackScript;
    List<ItemStruct> inventory = new List<ItemStruct>();

    void Start()
    {
        playerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerAttackScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        inventoryUi = GameObject.FindGameObjectWithTag("Inventory UI").GetComponent<Canvas>();
        inventoryUi.enabled = false;
    }

    void Update()
    {
        // Opens/closes the inventory UI, and disallows/allows movement and attack
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUi.enabled = !inventoryUi.enabled;
            playerMovementScript.canMove = inventoryUi.enabled;
            playerAttackScript.isInventoryOpen = inventoryUi.enabled;
        }
    }

    void UpdateInventory()
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            Image slot = GameObject.Find("item_slot" + (i + 1)).GetComponent<Image>();
            slot.sprite = inventory[i].ItemTexture;

            Text text = GameObject.Find("item_text" + (i + 1)).GetComponent<Text>();
            text.text = inventory[i].Quantity.ToString();
        }
    }

    // Increases the number of a certain item, or adds it to the inventory (if it's not there already)
    public void AddItem(GameObject item)
    {
        int itemId = item.GetComponent<ItemBase>().id;

        for (int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].Id == itemId)
            {
                inventory[i].Quantity++;
                Debug.Log(inventory[i].Quantity);
                UpdateInventory();
                return;
            }
        }

        ItemStruct newItem = new ItemStruct(item, 1);
        inventory.Add(newItem);
        UpdateInventory();
    }
}
