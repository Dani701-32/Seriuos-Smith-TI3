using UnityEngine;
<<<<<<< HEAD
=======


>>>>>>> 2dd570ec803635876ff8795c4d86fe5f9d8c6b4e

public class PlayerInterector : MonoBehaviour
{
    public GameObject interactor;
    /*
    public IInterectable currentInterectable = null;

    private void Update()
    {
        CheckInterectable(); 
    }
    private void CheckInterectable()
    {
        if (currentInterectable == null) return;
<<<<<<< HEAD
=======
        OnEnable(); 
        playerInteracion.performed  += context => currentInterectable.Interect();
>>>>>>> 2dd570ec803635876ff8795c4d86fe5f9d8c6b4e
    }

    private void OnTriggerEnter(Collider other)
    {
        //Recebe o objeto que deve ser interagido
        Debug.Log("ENCOTNROU"); 
        IInterectable interectable = other.GetComponent<IInterectable>();
        if (interectable == null) return;

        currentInterectable = interectable;

    }
    

    private void OnTriggerExit(Collider other)
    {
        IInterectable interectable = other.GetComponent<IInterectable>();
        if (interectable == null) return;
        if (interectable != currentInterectable) return;
<<<<<<< HEAD
=======
        OnDisable(); 
>>>>>>> 2dd570ec803635876ff8795c4d86fe5f9d8c6b4e
        currentInterectable = null;
    }
    */
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
    }
    
}