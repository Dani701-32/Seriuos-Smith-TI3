using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bigorna : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Item item, itemResult;
    [SerializeField] Slider slider;
    [SerializeField] Text batidasTexto;
    [SerializeField] float minValue = -1;
    [SerializeField] int batidasCertas;
    [SerializeField] int batidasErradas;
    [SerializeField] BluePrints bluePrints;
    States estados;
    public InventorySlot slotsBigorna, slotResult;

    public GameObject UI;
    public GameObject BotaoIniciar;
    public GameObject BotaoBater;
    private bool Clicar;

    void Awake()
    {
        //slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        _inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
        bluePrints = gameObject.GetComponent<BluePrints>();
        slider = GameObject.Find("BigornaSlider").GetComponent<Slider>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerMovement = p.GetComponent<PlayerMovement>();
        UI.SetActive(false);

    }

    public void AbrirTela()
    {
        UI.SetActive(true);
    }
    public void FecharTela()
    {
        UI.SetActive(false);
    }
    public void IdaSlider()
    {
        minValue += 0.3f * Time.deltaTime;

        slider.value = minValue;

    }


    public bool ClickItem(Item item)
    {
        if (this.item == null && item != null)
        {
            this.item = item;
            slotsBigorna.AddItem(item);
            return true;
        }
        return false;
    }
    public void PegarItem() // Função para clicar no slot e puxar o item ja feito para o inventario
    {
        if (item == null) return;
        _inventory.Add(item);
        slotsBigorna.ClearSlot();
        item = null;
        itemResult = null;
    }

    public void PegarResult()
    {
        if (itemResult == null) return;

        itemResult.ItemName = $"{item.ItemName} {itemResult.ItemName}";
        itemResult.materialType = item.materialType;
        itemResult.statesTypes = States.Ambiente;

        _inventory.Add(itemResult);
        slotResult.ClearSlot();
        slotsBigorna.ClearSlot();
        item = null;
    }

    public void GerarResult()
    {

        itemResult = bluePrints.CheckMolde(batidasCertas);
        slotResult.AddItem(itemResult);
    }

    public void Bater()
    {
        Debug.Log(100 - Mathf.Abs(minValue) * 100);
        if (minValue >= -0.2 && minValue <= 0.2)
        {
            batidasCertas++;
            batidasTexto.text = batidasCertas.ToString();
        }
        else batidasErradas++;

        minValue = -1;
        Clicar = false;
        BotaoIniciar.SetActive(true);
        //Animação de batida com coroutine
        BotaoBater.SetActive(false);
        if (item.statesTypes == States.Quente)
        {
            if (batidasCertas == item.minBatidas) item.trabState = TrabState.Moldando;
            if (batidasCertas >= item.limiteBatidas) item.trabState = TrabState.Quebrado;
        }
        GerarResult();
    }
    public void Iniciar()
    {
        Clicar = true;
        BotaoIniciar.SetActive(false);
        BotaoBater.SetActive(true);
        GI.playerHolderQuest.energy -= 10;
    }

    void Update()
    {
        if (Clicar)
        {
            IdaSlider();
        }
    }
}
