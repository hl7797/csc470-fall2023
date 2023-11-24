using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    private bool move = true;
    private Rigidbody rb;
    public float MoveSpeed = 6;
    public float rotateSpeed = 60;
    public float addSpeed = 10f;
    private Animator animator;
    public float maxMouseRotation = 45f;
    public GameObject fire;
    public Transform fire_pos;

    public float jumpForce = 5f; 
    public float groundCheckDistance ;
   
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            movement();
        }
       
        Rotate();
        Attack();
        Jump();
        Reload();
       // Debug.DrawRay(fire_pos.position, transform.forward * 50f, Color.red);
        
    }

    private void movement()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0|| vAxis !=0) 
        {           
            Vector3 movement = new Vector3(hAxis, 0f, vAxis) * MoveSpeed * Time.deltaTime;
            transform.Translate(movement);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = addSpeed;
            animator.SetBool("addSpeed",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = 3;
            animator.SetBool("addSpeed", false);
        }
    }
   
    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        mouseX = Mathf.Clamp(mouseX, -maxMouseRotation, maxMouseRotation);
        transform.Rotate(Vector3.up, mouseX * rotateSpeed);      
    }

  void Attack()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            move = false;
            animator.SetBool("Attack", true);
            fire.SetActive(true);
            bool res = Physics.Raycast(fire_pos.position, fire_pos.forward, 80, 1 << LayerMask.NameToLayer("enemy"));
            if (res)
            {
                print("hit");
            }
            
        }
      
        if (Input.GetMouseButtonUp(0)) 
        {
            move = true;
            animator.SetBool("Attack", false);
            fire.SetActive(false);
        }
    }

    
        void Jump()
    {
     
      
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            animator.SetBool("Jump", true);
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
           
        }
    }
    bool IsGrounded()
    {
       
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance);
    }

    void Reload()
    {

    }
}
