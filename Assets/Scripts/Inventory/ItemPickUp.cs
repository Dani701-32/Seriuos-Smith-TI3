using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    public void PickUp() // Colocar esse metodo dentro do Interector quando se colidor com os itens
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        PickUp();
    }
}
