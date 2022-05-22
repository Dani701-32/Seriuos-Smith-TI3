using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bigorna : Interactable
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] Slider slider;
    [SerializeField] float v = -1;
    public GameObject UI;
    public GameObject UI_Craft;
    private bool Clicar;
    
    void Awake()
    {
        //slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        _inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
        
    }
    public override void StayInteractor()
    {
        base.StayInteractor();
        UI.SetActive(true);
        UI_Craft.SetActive(true);
    }
    public void BaterMartelo()
    {
        v += 0.3f * Time.deltaTime;
        slider.value = v;
    }

    public void Bater()
    {
        Debug.Log(100 - Mathf.Abs(v) * 100);
        Clicar = true;
        v = -1;
    }

    void Update()
    {
        if (Clicar)
        {
            BaterMartelo();
        }
    }
}
