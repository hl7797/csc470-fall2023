//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyCtr : MonoBehaviour
{
    
  public float Ehealth=10f;
   
    private NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;
    private Animator animator;
    public float attackRange = 2f;
    private float timeSinceLastAttack = 0f;
    public float attackDelay = 1f;
    public bool die = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomTarget();
        animator = GetComponent<Animator>();                
    }
   

    void Update()
    {      
        if (die == true)
        {
            navMeshAgent.isStopped = true;
        }
            if (GameManager.Instance.target != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, GameManager.Instance.target.position);
                if (distanceToPlayer <= chaseRange)
                {
                    navMeshAgent.SetDestination(GameManager.Instance.target.position);
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
        if (Time.time - timeSinceLastAttack >= attackDelay)
        {
            animator.SetBool("Attack", true);
           animator.SetBool("Run", false);

            GameManager.Instance.health -= 10;
            timeSinceLastAttack = Time.time;
        }
    }   
}
