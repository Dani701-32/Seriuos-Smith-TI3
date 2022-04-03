using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
     private PlayerMovement player;

    private void Awake()
    {
        itemSlotContainer = transform.Find("In_itemSlot");
        itemSlotTemplate = itemSlotContainer.Find("In_itemSlotTemplate");
    }
    public void SetPlayer(PlayerMovement player)
    {
        this.player = player;
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) //Se o player pegar um item chama esse evento pra recarregar o inventário
    {
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 130f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotReact = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotReact.gameObject.SetActive(true);

            //Click do mouse
            // itemSlotReact.GetComponent<Button_UI>().ClickFunc = () =>
            // {
            //     //Usar item 
            //     //Não sabia se teria alguma utilidade então apenas vou deixar em branco por hora
            // };
            // itemSlotReact.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            // {
            //     //DropItem
            //     inventory.RemoveItem(item);
            //     ItemWorld.DropItem(player.GetPosition(), item);
            // };



            itemSlotReact.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotReact.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            Text uiText = itemSlotReact.Find("Text").GetComponent<Text>();


            uiText.text = (item.amount > 1) ? item.amount.ToString() : " "; //Verifica se a quantidade de items é maior que um. Se for Coloca a quantidade se n deixa vazia

            x++;
            if (x > 3) // Quando tiver 4 itens na mesma linha começa a preencher embaixo
            {
                x = 0;
                y--;
            }
        }
    }
}
