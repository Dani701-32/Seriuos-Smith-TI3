using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafts : MonoBehaviour
{
    public enum TypeOfCrafts
    {
        FORJA,
        BIGORNA,
        AFIADOR,
        ESFRIAR
    }
    [SerializeField] private Item item;
    [SerializeField] Inventory inventory;
    public TypeOfCrafts typesOfCrafts;
    public GameObject UI;
    public InventorySlot slot;
    public void teste()
    {
        typesOfCrafts = TypeOfCrafts.FORJA;
    }

    public void Window() { GI.SetVisible(UI, UI.activeSelf); }
    public bool ClickItem(Item item)
    {
        if (this.item == null && item != null)
        {
            this.item = item;
            slot.AddItem(item);
            return true;
        }
        return false;
    }
    public void PickItem() // Função para clicar no slot e puxar o item ja feito para o inventory
    {
        if (item == null) return;
        inventory.Add(item);
        slot.ClearSlot();
        item = null;
    }

}
