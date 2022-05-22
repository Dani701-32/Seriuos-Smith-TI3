using UnityEngine;

//Script para todos os objetos q forem interagir com o player
//Funciona ate o momento so com objetos TriggerEnter
public class Interactable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Interact();
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StayInteractor();
        }
    }
    public virtual void StayInteractor()
    {
         Debug.Log("Interagindo com: " + transform.name);
    }
    public virtual void Interact() // Metodo virtual pra ser reescrito com outros atributos de itens etc.
    {
        // Esse metodo funciona para chamar metodos dentro dele.
        //This method is meant to be overwritten
        Debug.Log("Interagindo com: " + transform.name);
    }
}
