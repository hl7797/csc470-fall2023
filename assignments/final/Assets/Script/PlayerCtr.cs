//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class PlayerCtr : MonoBehaviour
{
    private bool move = true;
    private bool attack = true;
    
    private Rigidbody rb;
    public float MoveSpeed = 6;
    public float rotateSpeed = 60;
    public float addSpeed = 10f;
    private Animator animator;
    public float maxMouseRotation = 45f;
    public GameObject fire;
    public Transform fire_pos;
    private Vector3 moving;
    public float jumpForce = 5f; 
    public float groundCheckDistance=0.1f ;

    public TMP_Text BulletNum;
    public int Bulletnum = 500;

    private RaycastHit raycastHit;
    private RaycastHit enemyHit;
    public float damage = 0.1f;

   


    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        BulletNum.text = Bulletnum.ToString();      
    }


   
    // Update is called once per frame
    void Update()
    {     
        if (move)
        {
            movement();
        }
       if (attack)
        {
            Attack();
          
        }
      
        Reload();
        dead();
        Rotate();
        Jump();

       
            if (Input.GetMouseButtonUp(0))
        {
            move = true;
            animator.SetBool("Attack", false);
            fire.SetActive(false);
        }
        if (Bulletnum <= -1)
        {
            attack = false;
            animator.SetBool("Attack", false);
            fire.SetActive(false);
        }
        // Debug.DrawRay(fire_pos.position, transform.forward * 50f, Color.red);

    }

    private void movement()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0|| vAxis !=0) 
        {           
             moving = new Vector3(hAxis, 0f, vAxis) * MoveSpeed * Time.deltaTime;
            transform.Translate(moving);
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
      
        BulletNum.text = Bulletnum.ToString();
        if (Input.GetMouseButton(0))
        {

            Bulletnum -= 1;
            move = false;
           
            animator.SetBool("Attack", true);
            fire.SetActive(true);
   
          Ray ray = new Ray(fire_pos.position, fire_pos.forward);
            GameManager.Instance.res = Physics.Raycast(ray, out enemyHit, 80, 1 << LayerMask.NameToLayer("enemy"));
            if (GameManager.Instance.res)
            {
                print("hit" + enemyHit.collider.name);
                Enemy enemy = enemyHit.collider.GetComponent<Enemy>();
                //EnemyCtr enemies = enemyHit.collider.GetComponent<EnemyCtr>();
                enemy.TakeDamage(damage);
                //enemies.die = true;
            }
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

        if (Bulletnum < 500 && Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Reload", true);
            animator.SetTrigger("move");
            Bulletnum = 500;
            attack = true;
            animator.SetTrigger("move");
        }
        else
        {
            animator.SetBool("Reload", false);
        }       
    } 
    
    void dead()
    {
        if (GameManager.Instance.health <= 0)
        {           
            GameManager.Instance.health = 0;
            animator.SetBool("Dead", true);
            Invoke("end", 1f);
        }
    }
    private void end()
    {
        SceneManager.LoadScene("End");
    }
}
