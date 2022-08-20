using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GI 
{
    public static Crafts crafts;
    public static Inventory inventory;
    public static PlayerMovement playerMovement;
    public static Player playerHolderQuest;



    public static void SetVisible(GameObject obj , bool visible)
    {
        obj.SetActive(visible);
    }
}
