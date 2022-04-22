using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{

    [SerializeField] SO_Item so_item;
    public Item item = new Item();
    [SerializeField] string itemType;
    [SerializeField] string nome;
    [SerializeField] int price;
    [SerializeField] int quantity;
    // Start is called before the first frame update
    void Start()
    {
        item.SetItem(so_item.itemType.ToString(), so_item.nome, so_item.price, so_item.quantity);
        itemType = item.Type; 
        nome = item.Nome;
        price = item.Price;
        quantity = item.Quantity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            bool test = inventory.AddItem(item);

            if (test)
            {
                Destroy(gameObject);
            }
        }
    }

}
