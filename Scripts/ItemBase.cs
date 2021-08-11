using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public Sprite inventoryIcon;
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddItem(gameObject);
            Destroy(gameObject);
        }
    }
}
