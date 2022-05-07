using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    public void PickUp()
    {
        Debug.Log("Pegando " + item.ItemName);
        bool wasPickUp = Inventory.instance.Add(item);   //Colocando o item no inventario
        
        if(wasPickUp)
        {
            Destroy(gameObject);
        }   
    }
}
