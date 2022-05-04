using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
// OS ITENS ESTAO FICANDO INVISIVEIS APENAS AGORA
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent; // Item no campo
    public GameObject InventoryItem; // Prefab 2D

    public Toggle enableRemove;
    public GameObject closeInventory;

    public InventoryItemController[] InventoryItems;
    public bool addController = false;


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
            item.gameObject.SetActive(false);
            //Destroy(item.gameObject);
        }


        if(InventoryItems.Length ==0) // Checa se tem algum item dentro da lista
        {
            foreach (var item in Items) // Adiciona os itens e imagens necessarios.
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

                itemName.text = item.ItemName;
                itemIcon.sprite = item.icon;

                if(enableRemove.isOn) // Checa se o botao de remover itens esta ativado.
                {
                    removeButton.gameObject.SetActive(true); 
                }
            }
            SetInventoryItems(); // Lista os itens todos novamente (Parte onde esta Bugado)
            addController = true;
        }
        else
        {
            addController = false;
        }

    }

    public void Close()
    {
        closeInventory.gameObject.SetActive(false);
    }

    public void SetInventoryItems() // Seta os filhos que possuem o script de InventoryItemsController
    {
        if(InventoryItems.Length == 0)
        {
            InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
            for (int i = 0; i < Items.Count; i++)
            {
                InventoryItems[i].AddItem(Items[i]);
            }
        }
    }
    
    
}
