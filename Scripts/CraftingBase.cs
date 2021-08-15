using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBase : MonoBehaviour
{
    private List<ItemStruct> ingredientList;
    private PlayerInventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void OpenCraftingScreen()
    {

    }
}
