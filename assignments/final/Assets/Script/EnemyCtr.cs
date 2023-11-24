using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyCtr : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // 目标（通常是玩家）

    private NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 设置初始目标
        SetRandomTarget();
    }

    void Update()
    {
        if (target != null)
        {
            // 计算与玩家的距离
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            // 如果在追击范围内
            if (distanceToPlayer <= chaseRange)
            {
                // 设置目标为玩家位置
                navMeshAgent.SetDestination(target.position);
            }
            else
            {
                // 如果到达目标点，设置新的目标
                if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
                {
                    SetRandomTarget();
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
}
