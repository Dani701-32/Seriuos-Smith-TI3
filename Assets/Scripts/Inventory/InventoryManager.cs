using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent; // Item no campo
    public GameObject InventoryItem; // Prefab 2D

    public Toggle enableRemove;

    public InventoryItemController[] InventoryItems;


    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
    }
    public void EnableItemRemove()
    {
        if (enableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
    public void ListItem()
    {
        //Limpar o inventario para nao duplicar o item
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }



        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.icon;

            if(enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true); 
            }
        }

        SetInventoryItems();
    }
    public void SetInventoryItems() // Seta os filhos que possuem o script de InventoryItemsController
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }


}
