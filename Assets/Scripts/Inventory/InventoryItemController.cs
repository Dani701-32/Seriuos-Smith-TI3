using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button removeButton;

    public void RemoveItem() // Logica para tirar os itens do Inventario
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
