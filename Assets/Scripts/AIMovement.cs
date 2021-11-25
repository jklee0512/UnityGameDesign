using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent m_enemy = null;

    [SerializeField] Transform[] m_tfWayPoints = null;

    int m_count = 0;

    void MoveToNextWayPoint()
    {
        if(m_enemy.velocity== Vector3.zero )
        {
            m_enemy.SetDestination(m_tfWayPoints[m_count++].position);
            if (m_count > m_tfWayPoints.Length)
                m_count = 0;
        }
    }

    void Start()
    {
        m_enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }

    void Update()
    {

    }
}
