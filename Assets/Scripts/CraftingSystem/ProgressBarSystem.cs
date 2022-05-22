using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSystem : MonoBehaviour
{
    public Inventory inventory;
    public Item item;
    public Slider slider;
    bool Clicar = false;
    float v = -1f;

    public void BaterMartelo()
    {
        v += 0.3f * Time.deltaTime;
        slider.value = v;
    }

    public void Bater()
    {
        foreach(Item obj in inventory.items)
        {
            if(inventory.space > 0)
            {
                if(item.itemType == Item.ItemType.Ferro)
                {
                    
                    Debug.Log(100 - Mathf.Abs(v) * 100);
                    Clicar = true;
                    v = -1;
                    inventory.Remove(item);
                }
                
                
            }
        }
    }

    void Update()
    {
        if (Clicar)
        {
            BaterMartelo();
        }
    }
    
}
