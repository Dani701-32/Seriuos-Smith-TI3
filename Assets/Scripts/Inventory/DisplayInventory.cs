using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    public int xStart;
    public int yStart;
    public InventoryObject inventory;
    public int xSpaceBetweenCollectable;
    public int ySpaceBetweenCollectable;
    public int numColluns;
    Dictionary<InventorySlot, GameObject> collectablesDisplay = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreadDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void CreadDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            collectablesDisplay.Add(inventory.Container[i], obj); 
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenCollectable * (i % numColluns)), yStart + (-ySpaceBetweenCollectable * (i / numColluns)), 0f);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (collectablesDisplay.ContainsKey(inventory.Container[i]))
            {
                collectablesDisplay[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                collectablesDisplay.Add(inventory.Container[i], obj); 

            }
        }

    }
}
