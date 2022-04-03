using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{

    private List<Item> itemList;

    public event EventHandler OnItemListChanged; //detecta uma mudança na lista
    //Constroi uma nova lista
    public Inventory()
    {
        itemList = new List<Item>();
        ItemWorld.SpwanItemWorld(new Vector3(10f,1f,3f), new Item { itemType = Item.ItemType.Wood, amount = 1 });//Linha para spawnar item
    }
    //Adciona um objeto a lista de items
    public void AddItem(Item item)
    {
        if (item.isStackable())
        {
            bool alreadyAdded = false;
            foreach (Item i_item in itemList)
            {
                if (i_item.itemType == item.itemType)
                {
                    i_item.amount += item.amount;
                    alreadyAdded = true;
                }
            }
            if (!alreadyAdded)
            {
                itemList.Add(item);
            }

        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);//Se a lista foi akterada 
    }

    public void RemoveItem(Item item)
    {
        if (item.isStackable())
        {
           Item item_Inventory  = null; 
            foreach (Item i_item in itemList)
            {
                if (i_item.itemType == item.itemType)
                {
                    i_item.amount -= item.amount;
                    item_Inventory = i_item; 
                }
            }
            if (item_Inventory != null)
            {
                itemList.Remove(item_Inventory);
            }

        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);//Se a lista foi akterada 
    }
    //Expose item 
    public List<Item> GetItemList() { return itemList; }

}
