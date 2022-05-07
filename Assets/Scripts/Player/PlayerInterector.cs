using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerInterector : MonoBehaviour
{
    /*
    public itemPickUp pickItem;
    public GameObject interactor;
    public Controller control;
    
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
        ProcessCollisions(other.gameObject);
    }
    private void OntriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Pedidos"))
        {
            fButton.SetActive(false);
            active = false;
        }
    }
    void ProcessCollisions(GameObject collisions)
    {
        Debug.Log("teste");
        
        /*if (collisions.gameObject.CompareTag("Item"))
        {
            pickItem.PickUp();
        }
        else if (collisions.gameObject.CompareTag("Pedidos"))
        {
            fButton.SetActive(true);
            active = true;

        }
    }
    public virtual void Interact()
    {
        Debug.Log("Interaction with: " + transform.name);
    }
    */
}