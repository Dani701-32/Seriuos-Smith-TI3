using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    public Item itemForja;
    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI; // Qualquer mudança na UI o delagate vai chamar a função UpdateUI

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); // pega todos os filhos do gameObject InventorySlots
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count) // se existe itens para ser adicionados no inventario
            {
                slots[i].AddItem(inventory.items[i]);   //adiciona na UI do inventario
                
            }
            else    // senao tiver items a ser adicionados
            {
                slots[i].ClearSlot();   //limpa os slots
            }
        }
    }
}
