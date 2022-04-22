using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> inventory = new List<Item>();
    [SerializeField] Item item = new Item();
    [SerializeField] private int size = 5;
    [SerializeField] private int currentSize = 0;

    public int position = 0;
    public bool AddItem(Item item)
    {

        this.item.SetItem(item);
        int iQ = this.item.Quantity;
        Debug.Log(Verify(item));

        if (Verify(item))
        {
            int inQ = inventory[position].Quantity;
            int total = iQ + inQ;
            Debug.Log("Quantidade Objeto: " + total);
            inventory[position].Quantity = (item.Quantity + inventory[position].Quantity);
            return true;
        }

        if (currentSize < size)
        {
            inventory.Add(this.item);
            currentSize++;
            return true;
        }



        return false;
    }

    private bool Verify(Item item)
    {
        position = 0;
        foreach (Item i in inventory)
        {
            if (i.Nome == item.Nome)
            {
                Debug.Log(i.Nome);
                return true;
            }
            position++;
        }

        return false;
    }
}
