using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInterector : MonoBehaviour
{
    public IInterectable currentInterectable = null;
    public InputAction playerInteracion;
    private void OnEnable()
    {
        playerInteracion.Enable();
    }

    private void OnDisable()
    {
        playerInteracion.Disable();
    }
    private void Update()
    {
        CheckInterectable(); 
    }
    private void CheckInterectable()
    {
        if (currentInterectable == null) return;
        OnEnable(); 
        playerInteracion.performed  += context => currentInterectable.Interect();
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
        OnDisable(); 
        currentInterectable = null;
    }
}
