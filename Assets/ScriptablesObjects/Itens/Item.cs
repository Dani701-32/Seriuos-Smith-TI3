using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string ItemName;
    public int value;
    public Sprite icon;
    public ItemType type; // aqui poderia fazer a comparação se o tipo do item e o msm que deve ser

    public enum ItemType
    {
        IronIngot,Wood
    }

}
