using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PeopleMoveCtr : MonoBehaviour
{




    // private bool Walking = false;
    public Slider Power;
    public float moveSpeed = 0.1f;
    private CharacterController cc;
    public GameObject EnemyObj;
    private Animator animator;
    
    float forwardSpeed = 10;
    float rotateSpeed = 150;
    float jumpForce = 18;
    float gravityModifier = 4.5f;
    float yVelocity = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Power.value += 0.0001f;
        if(Power.value > 0)
        {
            addSpeed();
        }
       
        attack();
        Move();
        
       
        }
    private void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);
        if (!cc.isGrounded)
        {

            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        }
        else
        {
            yVelocity = -1;



            if (Input.GetKey(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }
        Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;
        Vector3 amountToMove2 = vAxis * transform.forward * forwardSpeed;
        amountToMove2.y = yVelocity;


        cc.Move(amountToMove * Time.deltaTime);






        if (amountToMove.magnitude > 0 || hAxis != 0)
        {

            // Walking = true;
            animator.SetBool("Walking", true);
           // Power.value -= 0.0001f;

        }
        else
        {

            //Walking = false;
            animator.SetBool("Walking", false);
        }
    }
    private void addSpeed()
    {
            if (Input.GetKey(KeyCode.Space)) {
            forwardSpeed = 15;
            animator.SetBool("Gofast", true);
            Power.value -= 0.0002f;


        }
        else
        {
            forwardSpeed = 10;
            animator.SetBool("Gofast", false);
        }
    }

    private void attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
    
}


