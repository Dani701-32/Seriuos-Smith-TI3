using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Raw Material", menuName = "Inventory System/Items/RawMaterial")]

public class RawMaterial : ItemObject
{    public void Awake() {
        type = ItemType.RawMaterial; 
    }
}
