using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class SO_Item : ScriptableObject
{
    public enum ItemType
    {
        RawMaterial,
        Armor,
        Weapon,
        Ornament
    }
    public ItemType itemType;
    public string nome;
    public int price;
    public int quantity;
}
