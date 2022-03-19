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
        currentInterectable = null;
    }
}
