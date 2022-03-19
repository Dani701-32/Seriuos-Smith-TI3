using UnityEngine;
public class PlayerInterector : MonoBehaviour
{
    public IInterectable currentInterectable = null;

    private void Update()
    {
        CheckInterectable(); 
    }
    private void CheckInterectable()
    {
        if (currentInterectable == null) return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentInterectable.Interect(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Recebe o objeto que deve ser interagido
        IInterectable interectable = other.GetComponent<IInterectable>();
        if (interectable == null) return;
        currentInterectable = interectable;

    }
    

    private void OnTriggerExit(Collider other)
    {
        IInterectable interectable = other.GetComponent<IInterectable>();
        if (interectable == null) return;
        if (interectable != currentInterectable) return;
        currentInterectable = null;
    }

    // void OnTriggerStay(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Interactable")) // poderia usar um bool pra checar apenas uma vez mas sla
    //     {
    //         if(Input.GetKey(KeyCode.F))
    //         {
    //             interactor.SetActive(true);
    //             Debug.Log("Test");
    //         }
    //     }
    // }
    
}