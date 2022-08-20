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
    //New movimentation
    /*// position , velocity , acceleration
    public Vector3 p, dp, ddp;
    [Header("Movement Session")]
    public float acc = 100.0f;
    public float friction = 17.0f;
    float dt;
    [Header("Component Session")]
    public CharacterController characterController;

    [Header("Gravity Variables")]
    float gravity = 9.8f;
    float ground_gravity = -.05f;

    [Header("Jump Variables")]
    bool isJumpPressed = false;
    public float initial_jump_velocity;
    public float max_jump_height = 1.0f;
    public float max_jump_time = 0.5f;
    bool is_jumping = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        setupJumpVariables();
    }

    public void Update()
    {
        ddp = Vector3.zero;

        dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) { ddp.z += 1; animator.SetBool("IsMoving", true); } else animator.SetBool("IsMoving", false);
        if (Input.GetKey(KeyCode.S)) { ddp.z -= 1; animator.SetBool("IsMoving", true); } else animator.SetBool("IsMoving", false);
        if (Input.GetKey(KeyCode.A)) { ddp.x -= 1; animator.SetBool("IsMoving", true); } else animator.SetBool("IsMoving", false);
        if (Input.GetKey(KeyCode.D)) { ddp.x += 1; animator.SetBool("IsMoving", true); } else animator.SetBool("IsMoving", false);
        if (characterController.isGrounded)
            if (Input.GetKeyDown(KeyCode.Space)) { dp.y = initial_jump_velocity; }

        ddp = ddp.normalized;
        ddp *= acc;
        ddp.x -= dp.x * friction;
        ddp.z -= dp.z * friction;

        ddp.y -= 9.81f;

        dp += ddp * dt;
        p = (ddp * dt * dt * 0.5f) + (dp * dt);

        characterController.Move(p);
    }

    void setupJumpVariables()
    {
        float time_to_apex = max_jump_time / 2;
        gravity = (-2 * max_jump_height / Mathf.Pow(time_to_apex, 2));
        //initial_jump_velocity = (2 * max_jump_height / time_to_apex);
        initial_jump_velocity = Mathf.Sqrt(-2 * max_jump_height * -9.81f);
    }
    void jumpHandle()
    {
        if (isJumpPressed)
        {
            dp.y = initial_jump_velocity;
        }
    }
    void onJump()
    {
        //if (Input.GetKey(KeyCode.Space)) Debug.Log("Jump");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
            Debug.Log("IsPressed");
        }
        else
        {
            isJumpPressed = false;
        }
    }*/

}
