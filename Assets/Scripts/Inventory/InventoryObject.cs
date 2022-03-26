using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject item, int amount)
    {
        bool hasItem = false;
        foreach (InventorySlot slot in Container)
        {
            if (slot.item == item)
            {
                slot.AddAmout(amount);
                hasItem = true;
                break;
            }

        }
        if (!hasItem) Container.Add(new InventorySlot(item, amount));
    }

}
[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void AddAmout(int value)
    {
        amount += value;
    }
}