//using System.Collections;
//sing System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private bool hasAttacked = false;
    private Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        autoAttack();
      
    }

    private void autoAttack()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;
        float rayLength = 2.5f;
        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {        
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                animator.SetBool("Attack", true);
              
                hasAttacked = true;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            hasAttacked = false;
        }
        if (hasAttacked ==true)
        {
            GameManager.Instance.HealthChanging();
        }
    }
}
