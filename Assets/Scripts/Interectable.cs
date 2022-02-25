using UnityEngine;

public class Interectable : MonoBehaviour
{
    //
    public float radius = 3f; //Distância que o player precisa estar do objeto para interagir com ele
    //Desenha um circulo ao redor do obejto
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, radius); 
        
    }


}
