//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyCtr : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; 

    private NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;
    private Animator animator;
    public float attackRange = 2f;
    private float timeSinceLastAttack = 0f;
    public float attackDelay = 1f; // ¹¥»÷¼ä¸ô
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomTarget();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        die();
      
            if (target != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, target.position);
                if (distanceToPlayer <= chaseRange)
                {
                    navMeshAgent.SetDestination(target.position);
                    navMeshAgent.speed = 5f;
                    animator.SetBool("Run", true);
                    if (distanceToPlayer <= attackRange)
                    {

                        Attack();
                    }
                }
                else
                {
                    animator.SetBool("Attack", false);
                    if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
                    {
                        navMeshAgent.speed = 1f;
                        SetRandomTarget();
                        animator.SetBool("Run", false);
                    }
                }
            }
        
    }

    void SetRandomTarget()
    {
        Vector3 randomPoint = Random.insideUnitSphere * 10f;
        randomPoint += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas);      
        navMeshAgent.SetDestination(hit.position);
    }
    void Attack()
    {
        // ¼ì²é¹¥»÷¼ä¸ô
        if (Time.time - timeSinceLastAttack >= attackDelay)
        {
            animator.SetBool("Attack", true);
           animator.SetBool("Run", false);

            GameManager.Instance.health -= 10;
            timeSinceLastAttack = Time.time;
        }
    }

    void die()
    {
        if (GameManager.Instance.Ehealth<=1)
        {
           
            animator.SetBool("die", true);
            Invoke("Enemydisappear", 2f);
        }
    }
    void Enemydisappear()
    {
        gameObject.SetActive(false);
    }
}
