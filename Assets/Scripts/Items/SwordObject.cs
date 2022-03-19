using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Sword", menuName = "Inventory System/Items/Weapons/Sword")]

public class SwordObject : ItemObject
{
    public int bladeWeight; 
    public int bladeLengh; 
    public int bladeResistence; 
    public  void Awake() {
        type = ItemType.Weapons; 
    }
}
