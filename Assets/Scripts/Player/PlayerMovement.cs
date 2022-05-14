using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6;
    private Animator animator;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (Horizontal , 0f , Vertical).normalized;

        if(direction != Vector3.zero)
        {

        }

        if(direction.magnitude >= 0.1f && direction != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            float targetAngle = Mathf.Atan2(direction.x , direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // função matematica que calcula a direção do X e do Z e calcula o angulo que vai apontar a camera.
            float angle =  Mathf.SmoothDampAngle(transform.eulerAngles.y , targetAngle , ref turnSmoothVelocity , turnSmoothTime); // função pra deixar a rotação mais suave.
            
            transform.rotation = Quaternion.Euler(0f , angle , 0f); //rotação do objeto apicado.
            
            Vector3 moveDirection = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward; // Transforma a rotação da camera na sua direção que vai andar o player
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        else 
        {
            animator.SetBool("IsMoving", false);
        }
    }
    


}
