using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordObject : ItemObject
{
    public int bladeWeight; 
    public int bladeLengh; 
    public int bladeResistence; 
    public  void Awake() {
        type = ItemType.Weapons; 
    }
}
