using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float detectionRadius=20f;
    EnemyLocomotion enemyLocomotion;
    EnemyAnimatorManager enemyAnimatorManager;
    public EnemyStats enemyStats;
    public CharacterStats currentTarget;
    public NavMeshAgent navMeshAgent;
    public Rigidbody enemyRigidBody;
    public PatrolState patrolState;
    
   

    public State currentState;

    public bool isPerformingAction;
    //FOV
    public float maximunDetectionAngle = 50;
    public float minimunDetectionAngle = -50;
    public float viewableAngle;
    public float currentRecoveryTime = 0;
    public float stoppingDistance = 2.5f;
    public float movement = 0f;
    public float maxMovement = 0f;
    public float minMovement = 1f;
   

    public float enemySpeed = 0f;

    public float maximunAttackRange = 2f;
  
    public float distancefromTarget;
    
    public float rotationSpeed = 15;
    //Array de Ataques
    //   public EnemyAttackAction[] enemyAttacks;
    //   public EnemyAttackAction currentAttack;
    private void Awake()
    {
        enemyLocomotion = GetComponent<EnemyLocomotion>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        enemyStats = GetComponent<EnemyStats>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyRigidBody = GetComponent<Rigidbody>();

        
        switch (patrolState.currentArea)
        {
            case 1:
                patrolState.currentPivot = patrolState.A1Pivots[0];
                patrolState.pivotCounter = 2;
                break;
            case 2:
                patrolState.currentPivot = patrolState.A2Pivots[0];
                patrolState.pivotCounter = 2;
                break;
            case 3:
                patrolState.currentPivot = patrolState.A3Pivots[0];
                patrolState.pivotCounter = 2;
                break;
            case 4:
                patrolState.currentPivot = patrolState.A4Pivots[0];
                patrolState.pivotCounter = 2;
                break;
        }

    }
    private void Start()
    {
        navMeshAgent.enabled = false;
        enemyRigidBody.isKinematic = false;

        

    
}

    // Update is called once per frame
    void Update()
    {
        HandleRecoveryTimer();
        
    }

    private void FixedUpdate()
    {
        HandleCurrentAction();
    }

    public void HandleCurrentAction()
    {
        if (currentState != null)
        {
            State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);
      

            if (nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }

       /* if (enemyLocomotion.currentTarget != null)
        {
            enemyLocomotion.distancefromTarget = Vector3.Distance(enemyLocomotion.currentTarget.transform.position, transform.position);

        }

        if (enemyLocomotion.currentTarget == null)
        {
            enemyLocomotion.HandleDetection();
        }
        else if (enemyLocomotion.distancefromTarget > enemyLocomotion.stopingDistance)
        {
            enemyLocomotion.HandleMovetoTarget();
        }
        else
        {
            AttackTarget();
        }*/
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }

    public void HandleRecoveryTimer()
    {
        if (currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if (isPerformingAction)
        {
            if (currentRecoveryTime <= 0)
            {
                isPerformingAction = false;
            }
        }
    }
    
}
