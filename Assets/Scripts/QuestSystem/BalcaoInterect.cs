using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalcaoInterect : Interactable
{
    public GameObject questSystemUI;
    bool hasActive = false;
    public void OnTriggerEnter(Collider other)
    {
        hasActive = true;
    }
    public void SetCanvasActive()
    {
        if(Input.GetButtonDown("Interaction") && hasActive)
        {
            questSystemUI.SetActive(!questSystemUI.activeSelf);
            Debug.Log("Balcao");
            hasActive = false;
        }
    }
    public void Update()
    {
        SetCanvasActive();
    }
}
