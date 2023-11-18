//using System.Collections;
//sing System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;
//using UnityEngine.UI;
//using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private bool hasAttacked = false;
    private Animator animator;
    public Transform target; 
    public float speed;
   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        autoAttack();
        if (GameManager.Instance.FunState)
        {
            Moving();
        }
        else
        {
            animator.SetBool("Move", false);
        }
      
       
      
    }

    private void autoAttack()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;
        float rayLength = 1.5f;
        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {        
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
              
                animator.SetBool("Attack", true);
                GameManager.Instance.FunState = false;
                hasAttacked = true;
            }
        }
        else
        {
            GameManager.Instance.FunState = true;
            animator.SetBool("Attack", false);
            hasAttacked = false;
        }
        if (hasAttacked ==true)
        {
            GameManager.Instance.HealthChanging();
        }
    }
    private void Moving()
    {
        animator.SetBool("Move", true);        
        Vector3 targetDirection = target.position - transform.position;       
        Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);      
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 200);
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
