using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerInterector : MonoBehaviour
{
    public GameObject interactor;
    public Controller control;
    public Spawn spawner;
    public QuestGiver quest;
    public GameObject canvasSlider;
    public GameObject requestCanvasUI;
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Interactable")) // poderia usar um bool pra checar apenas uma vez mas sla
        {
            if(Input.GetKey(KeyCode.F))
            {
                interactor.SetActive(true);
                Debug.Log("Test");
            }
        }
        else if(other.gameObject.CompareTag("Tree")) // interaçao com a arvore
        {
            if(Input.GetKey(KeyCode.F))
            {
                control.IsCutting = true;
                Debug.Log("anothertest");
                spawner.TimeSpawner();
            }
        }
        else if(other.gameObject.CompareTag("Smith2")) // interaçao com a forja
        {
            if(Input.GetKey(KeyCode.F))
            {
                canvasSlider.SetActive(true);
            }
        }
        else if(other.gameObject.CompareTag("Counter")) // interaçao com o balcao
        {
            if(Input.GetKey(KeyCode.F))
            {
                quest.OpenQuestWindow();
                requestCanvasUI.SetActive(true);       
            }
        }
    } 
}