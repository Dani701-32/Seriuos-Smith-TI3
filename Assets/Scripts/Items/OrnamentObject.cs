using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ornament", menuName = "Inventory System/Items/Ornament")]

public class OrnamentObject : ItemObject
{
    public void Awake() {
        type = ItemType.Ornaments; 
    }

}
