using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyCtr : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Ŀ�꣨ͨ������ң�

    private NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // ���ó�ʼĿ��
        SetRandomTarget();
    }

    void Update()
    {
        if (target != null)
        {
            // ��������ҵľ���
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            // �����׷����Χ��
            if (distanceToPlayer <= chaseRange)
            {
                // ����Ŀ��Ϊ���λ��
                navMeshAgent.SetDestination(target.position);
            }
            else
            {
                // �������Ŀ��㣬�����µ�Ŀ��
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
