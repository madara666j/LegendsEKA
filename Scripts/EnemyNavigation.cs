using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public Transform target;
    [SerializeField] private EnemyHealth health;
    [SerializeField] private float timeBetweenAttacks = 2;

    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private Animator animator;
    private float lastAttackTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead())
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", navMeshAgent.velocity.magnitude > 0.5f);
            navMeshAgent.SetDestination(target.position);
            navMeshAgent.SetDestination(target.position);

            if(Vector3.Distance(transform.position, target.position) < 2.2f)
            {
                if(Time.time > lastAttackTime+ timeBetweenAttacks)
                {
                    animator.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                }
            }
        }

    }
}