using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerInterector : MonoBehaviour
{
    public GameObject interactor;
    public Controller control;
    public Spawn spawner;
    public QuestGiver giver;
    public GameObject fButton;
    bool active;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && active == true)
        {
            giver.OpenQuestWindow();
            fButton.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("teste");
        ItemPickUp pickUp = other.GetComponent<ItemPickUp>();

        if (other.gameObject.CompareTag("Interactable")) // poderia usar um bool pra checar apenas uma vez mas sla
        {
            fButton.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                interactor.SetActive(true);
                Debug.Log("Test");
                fButton.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Tree")) // interaçao com a arvore
        {
            fButton.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                control.IsCutting = true;
                Debug.Log("anothertest");
                spawner.TimeSpawner();
                fButton.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            pickUp.PickUp();
        }
        else if (other.gameObject.CompareTag("Pedidos"))
        {
            fButton.SetActive(true);
            active = true;
            
        }
    }
    private void OntriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pedidos"))
        {
            fButton.SetActive(false);
            active = false;
        }
    }
}