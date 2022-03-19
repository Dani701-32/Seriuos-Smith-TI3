using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public Rigidbody rb;
    float moveX, moveZ;

    Vector3 moveDirection = Vector3.zero;

    void Update()
    {

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


}
