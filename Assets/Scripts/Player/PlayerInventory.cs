using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UI_Inventory ui_Inventory; // Interfazer de ui
    private Inventory inventory; //Lista de Inventário

    private void Awake()
    {
        inventory = new Inventory();
        ui_Inventory.SetInventory(inventory);
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem()); //Pega o item e adiona no inventário
            itemWorld.DestroySelf(); //Destroi o item
        }
    }

}
