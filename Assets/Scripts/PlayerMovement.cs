using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public Rigidbody rb;
    float moveX, moveZ;

    bool inRange = false;

    public InputAction playerMoviment;
    public InputAction playerInteract;

    Vector3 moveDirection = Vector3.zero;
    private void OnEnable()
    {
        playerMoviment.Enable();
        playerInteract.Enable();
    }

    private void OnDisable()
    {
        playerInteract.Enable();
        playerMoviment.Disable();
    }

    void Update()
    {
        moveDirection = playerMoviment.ReadValue<Vector3>();


        //Se clicar em R
        
        

    }

    //Chamado em uma quantidade especifica de vezes por frame pra manter a fisica normal
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.z * moveSpeed);
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotateSpeed);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Interectable interectable = collider.GetComponent<Interectable>();

        if (interectable != null)
        {
            Debug.Log("Entrando na Area Interativa");
        }

    }
    void OnTriggerExit(Collider collider)
    {
        Interectable interectable = collider.GetComponent<Interectable>();

        if (interectable != null)
        {
            Debug.Log("Saindo da Area Interativa");
        }

    }


}
