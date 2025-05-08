using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;
    private Animator animator;
    [SerializeField] private int health = 3;

    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackCooldown = 1.5f;

    private float lastTimeAttack;
    private bool isAttacking;
    private bool isDead = false;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            navAgent.isStopped = true;
            Attack();
        }
        else
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(target.position);
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsAttacking", false);
        }



        if (health <= 0)
        {
            Die();
         }
            
    }

    private void Die()
    {
        if (isDead) return;
        
        isDead = true;
        GameManager.Instance.enemieCount--;
        GameManager.Instance.UpdateEnemieCounter();
        navAgent.isStopped = true;
        animator.SetBool("IsDead",true);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.5f);
    }

    public void GetHit(int damage)
    {
        //recibe daño y le baja la vida
        health -= damage;
    }

    private void Attack()
    {
        if (Time.time - lastTimeAttack >= attackCooldown)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null) 
            {
                playerHealth.TakeDamage(attackDamage);
            }
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking" , true);

            lastTimeAttack = Time.time;
        }
    }
}
