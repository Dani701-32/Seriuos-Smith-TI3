using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Item item;
    [SerializeField] private Text textButton;
    [SerializeField] private ForgeUI forjaUI;
    [SerializeField]Inventory inventario;
    [SerializeField] Slider slider;
    States estados; // 
    public InventorySlot slotForja;
    public GameObject UI_Forja;
    public bool taPegandoFogo;
    float temperatura;
    
    
    //Adicionar combustivel depois
    void Awake()
    {
        inventario = gameObject.GetComponent<Inventory>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerMovement = p.GetComponent<PlayerMovement>();
        textButton = GameObject.Find("T_Esquentar").GetComponent<Text>();
        slider = GameObject.Find("FornalhaSlider").GetComponent<Slider>();
        UI_Forja.SetActive(false);
        taPegandoFogo = false;
        temperatura = 25;
        textButton.text = "Ascender";
    }
    public void AbrirTela()
    {
        UI_Forja.SetActive(true);
        playerMovement.enabled = false;
    }
    public void FecharTela()
    {
        playerMovement.enabled = true;
        UI_Forja.SetActive(false);
    }
    public bool ClickItem(Item item)
    {
        if(this.item == null)
        {
            this.item = item;
            slotForja.AddItem(item);
            return true;
        }
        return false;
    }
    public void Fogo()
    {
        taPegandoFogo = (taPegandoFogo)? false : true;

        textButton.text = (taPegandoFogo)? "Apagar" : "Ascender";
    }
    private void EsquentarItem()
    {
        if(item == null) return;
        item.temperatura = temperatura;
        if(item.temperatura >= item.temperaturaQuente && item.temperatura < item.temperaturaQueimado)
        {
            item.statesTypes = States.Quente;
        }
        else if(item.temperatura >= item.temperaturaQueimado)
        {
            item.statesTypes = States.Queimado;
        }
    }
    public void PegarItem()
    {
        if(item == null) return;
        inventario.Add(item);
        slotForja.ClearSlot();
    }
    public void FixedUpdate()
    {
        if(taPegandoFogo)
        {
            temperatura += 30f * Time.deltaTime;
            slider.value = temperatura;
            EsquentarItem();
        }
        else if(temperatura > 25 && !taPegandoFogo )
        {
            temperatura -= 30f * Time.deltaTime;
            slider.value = temperatura;
            EsquentarItem();
        }
    }
}