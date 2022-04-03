using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        Axes,
        Hammer,
        Spear,
        Shild,
        Helmet,
        Chestplate,
        Armplate,
        Legplate,

        Wood,
        Iron,
        Copper,
        Steel
    }
    public ItemType itemType;
    public int amount;

    //Definie os Sprites dos Items
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.Wood: return ItemAssets.Instance.woodSprite;
            case ItemType.Steel: return ItemAssets.Instance.steelSprite;
        }
    }

    //Definir o objeto 3d do item a ser criado
    public Transform GetTransform()
    {
        switch (itemType)
        {
            default:
            case ItemType.Wood: return ItemAssets.Instance.woodPrefab;
            case ItemType.Steel: return ItemAssets.Instance.steelPrefab;
        }
    }

    public bool isStackable() //Verifica se os itens podem se sobrepor uns aos outros
    {
        switch (itemType)
        {
            default:
            case ItemType.Wood:
            case ItemType.Steel:
            case ItemType.Iron:
            case ItemType.Copper:
                return true;
            case ItemType.Sword:
            case ItemType.Axes:
            case ItemType.Hammer:
                return false;


        }
    }


}
