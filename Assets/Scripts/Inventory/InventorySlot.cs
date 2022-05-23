using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;  // Icone do ScriptableObject 
    public Button removeButton; //Botao de remover o item do inventario
    [SerializeField] private Forge forjao;
    [SerializeField] private Bigorna bigorna;
    public Item item;

    void Awake()
    {
        bigorna = GameObject.FindGameObjectWithTag("GameController").GetComponent<Bigorna>();
        forjao = GameObject.FindGameObjectWithTag("GameController").GetComponent<Forge>();
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);    // Pega o item dentro do inventario e remove ele da lista.
    }
    public void UseItemSlot() // clicar no item e usar ele.
    {
        if(forjao.ClickItem(item))  Inventory.instance.Remove(item);

    }
    public void BigornaUseItem()
    {
        if(bigorna.ClickItem(item)) Inventory.instance.Remove(item);
    }
}
