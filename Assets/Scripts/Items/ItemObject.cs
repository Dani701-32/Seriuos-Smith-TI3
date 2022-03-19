using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Types of objet in the game
public enum ItemType
{
    RawMaterial,
    Armor,
    Weapons,
    Ornaments

}
public enum Rarity
{
    Commum,
    Uncommum,
    Rare,
    Legendary
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab; //Store the prefab for the object
    public ItemType type; //Store the type of the object 

    public Rarity rarity; // Rarity of the item
    public int price; 
    [TextArea(15, 20)]
    public string description; //The description of the object

}

