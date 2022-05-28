using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Item item;
    [SerializeField]Inventory inventario;
   
    //[SerializeField] private ForgeUI forjaUI;
    [SerializeField] Slider slider;
    [SerializeField] Text textoTemperatura;
    States estados; // 
    public InventorySlot slot;
    public GameObject UI_Forja;
    public bool taPegandoFogo;
    float temperatura;
    
    
    //Adicionar combustivel depois
    void Awake()
    {
        inventario = gameObject.GetComponent<Inventory>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerMovement = p.GetComponent<PlayerMovement>();
        
        slider = GameObject.Find("FornalhaSlider").GetComponent<Slider>();
        taPegandoFogo = false;
        temperatura = 25;
        
        UI_Forja.SetActive(false);
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
    public bool ClickItem(Item item) // Coloca o item no slot
    {
        if(this.item == null && item != null)
        {
            this.item = item;
            slot.AddItem(item);
            return true;
        }
        return false;
    }
    public void PegarItem() // Função para clicar no slot e puxar o item ja feito para o inventario
    {
        if(item == null) return;
        inventario.Add(item);
        slot.ClearSlot();
        item = null;
    }
    public void Fogo()
    {
        taPegandoFogo = (taPegandoFogo)? false : true;

        
    }
    private void EsquentarItem() // Esquenta o material
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
    public void FixedUpdate()
    {
        if(taPegandoFogo)
        {
            temperatura += 30f * Time.deltaTime;
            slider.value = temperatura;
            textoTemperatura.text = temperatura.ToString();
            EsquentarItem();
        }
        else if(temperatura > 25 && !taPegandoFogo )
        {
            temperatura -= 30f * Time.deltaTime;
            slider.value = temperatura;
            textoTemperatura.text = temperatura.ToString();
            EsquentarItem();
        }
    }
}
