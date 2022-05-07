using UnityEngine;


//Script para todos os objetos q forem interagir com o player
public class Interactable : MonoBehaviour 
{
    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Interact();
    }
    public virtual void Interact() // Metodo virtual pra ser reescrito com outros atributos de itens etc.
    {
        //This method is meant to be overwritten
        Debug.Log("Interagindo com: " + transform.name);
    }
}
