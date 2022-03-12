using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 5.0f; // speed da camera
    public Transform target; // Transform do player
    public Vector3 offset = Vector3.zero; // Distancia entre a camera e o player normalizada
    public bool lookAt = false; //Olhar para o player ou nao

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,target.position + offset , speed * Time.deltaTime); // Movimentação
        
        if(lookAt)
        transform.LookAt(target.position);

    }
}
