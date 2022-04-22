using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    [SerializeField] string itemType;
    [SerializeField] string nome;
    [SerializeField] int price;
    [SerializeField] int quantity;
    public void SetItem(string type, string nome, int price, int quantity)
    {
        itemType = type;
        this.nome = nome;
        this.price = price;
        this.quantity = quantity;
    }

    public void SetItem(Item item)
    {
        this.itemType = item.Type;
        this.nome = item.Nome;
        this.price = item.Price;
        this.quantity = item.Quantity;
    }

    public string Type { get { return itemType; } }
    public string Nome { get { return nome; } }
    public int Price { get { return price; } }
    public int Quantity { get { return quantity; }  set { quantity = value; } }
}
