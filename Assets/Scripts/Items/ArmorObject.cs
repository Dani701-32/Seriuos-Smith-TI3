using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Armor", menuName = "Inventory System/Items/Armor")]

public class ArmorObject : ItemObject
{
    public enum ArmorPieces
    {
        Helmet, 
        Gauntlets,
        ChestArmor,
        LegArmor 
    }
    public int weight; 
    public ArmorPieces armorPieces; 
    public void Awake() {
        type = ItemType.Armor; 
    }
    
}
