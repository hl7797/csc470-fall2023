
using UnityEngine;
using TMPro;




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

    
    private RaycastHit enemyHit;
    public float damage = 1f;

    public SFader sceneFader;

    public AudioClip footStepSound;
    private float footStepDelay = 0.7f;

    private float nextFootstep = 0;
    public AudioClip gunSound;
    public float gunDelay;

    private float nextgun = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        BulletNum.text = Bulletnum.ToString();
        GameManager.Instance.keys.SetActive(false);
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
            PlayFootstepSound();
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            footStepDelay = 0.45f;
            MoveSpeed = addSpeed;
            animator.SetBool("addSpeed",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            footStepDelay = 0.7f;
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
            PlayGunSound();
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
               
                enemy.TakeDamage(damage);
               
            }
        }
    }

    
        void Jump()
    {     
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            animator.SetBool("Jump", true);
           
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

        if (Bulletnum < 800 && Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Reload", true);
            animator.SetTrigger("move");
            Bulletnum = 800;
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
            sceneFader.FadeOut("End");
            GameManager.Instance.endGame = false;

        }
    }
    public void OnTriggerEnter(Collider p)
    {
        if (p.CompareTag("pc") )
        {
            GameManager.Instance.missionGuide.text = "Copying\n Do not move";
           
            GameManager.Instance.I.enabled = true;
            GameManager.Instance.progress.enabled = true;

        }
       
        
    }
    public void OnTriggerStay(Collider p)
    {

        if (p.CompareTag("pc"))
        {
            GameManager.Instance.missionGuide.text = "Copying\nDo not move";
            
            GameManager.Instance.progress.rectTransform.sizeDelta = new Vector2(GameManager.Instance.progress.rectTransform.sizeDelta.x + 20 * Time.deltaTime, GameManager.Instance.progress.rectTransform.sizeDelta.y);
            if (GameManager.Instance.progress.rectTransform.sizeDelta.x >= 100)
            {
                GameManager.Instance.missionGuide.text = "Finish\nPress 'E' to collect\n Find key to retreat";
                GameManager.Instance.I.enabled = false;
                GameManager.Instance.progress.enabled = false;
              
                
                GameManager.Instance.finish = true;
                
            }
        }
        if (p.CompareTag("key"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.missionGuide.text = "Ready to retreat ";
                GameManager.Instance.finish = false;
              
                GameManager.Instance.keys.SetActive(false);
                GameManager.Instance.getKey = true;
            }
        }
        if (p.CompareTag("gate") && GameManager.Instance.getKey == true)
        {
           
            GameManager.Instance.missionGuide.text = "Press 'E' to leave";
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.endGame = true;
                sceneFader.FadeOut("End");
            }

        }

    }
    public void OnTriggerExit(Collider p)
    {
        if (p.CompareTag("pc"))

        {
            GameManager.Instance.missionGuide.text = "Replication terminated";
            if (GameManager.Instance.progress.rectTransform.sizeDelta.x >= 100)
            {
                GameManager.Instance.missionGuide.text = " Find key to retreat\n Press 'E' to collect";
            }
                GameManager.Instance.I.enabled = false;
            GameManager.Instance.progress.enabled = false;
           
        }
    }
    void PlayFootstepSound()
    {
        nextFootstep -= Time.deltaTime;
        if (nextFootstep <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
            nextFootstep += footStepDelay;
        }

    }
    void PlayGunSound()
    {
        nextgun -= Time.deltaTime;
        if (nextgun <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(gunSound, 0.7f);
            nextgun += gunDelay;
        }

    }
}
