using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PursueTarget pursueState;
    public IdleState idleState;
    public EscapeState escapeState;
    public LayerMask detectionLayer;
    public GameObject[] A1Pivots;
    public GameObject[] A2Pivots;
    public GameObject[] A3Pivots;
    public GameObject[] A4Pivots;

    public GameObject currentPivot;
    public int currentArea = 0;
    public int pivotCounter = 1;
    public int rotations = 0;
    public bool escape=false;

    public bool playerfinder = false;

    public AudioClip peacefulSong;
    public AudioSource audioSource;
    public bool peaceMusicStarts;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (peaceMusicStarts)
        {
            audioSource.clip = peacefulSong;
            audioSource.Play(0);
            peaceMusicStarts = false;
        }

        //Buscar al objetivo
        //Cambiar a perseguir al objetivo
        //sino, volver a este estado
        //Si se sale el objetivo, volver a buscarlo
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, enemyManager.detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
            if (characterStats != null)
            {

                Vector3 playerDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(playerDirection, transform.forward);

                if (viewableAngle > enemyManager.minimunDetectionAngle && viewableAngle < enemyManager.maximunDetectionAngle)
                {
                    print("Aqui llega");
                    enemyManager.currentTarget = characterStats;
                    playerfinder = true;

                }
            }

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Perseguir al objetivo
        if (enemyManager.isPerformingAction)
            return this;

        Vector3 targetDirection = currentPivot.transform.position - transform.position;
        enemyManager.distancefromTarget = Vector3.Distance(currentPivot.transform.position, transform.position);
        enemyManager.viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        //Si hace una accion


        if (enemyManager.isPerformingAction)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            enemyManager.navMeshAgent.enabled = false;
        }
        else
        {
            if (enemyManager.distancefromTarget >= 1)
            {
                targetDirection.Normalize();
                targetDirection.y = 0;
                
                   
                
                if (escapeState.escape)
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                    enemyManager.enemySpeed = 10;

                }
                else
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 0.5f, 0.1f, Time.deltaTime);
                    enemyManager.enemySpeed = 4;

                }
                targetDirection *= enemyManager.enemySpeed;
                
                
                Vector3 projectedVelocity = Vector3.ProjectOnPlane(targetDirection, Vector3.up);
                enemyManager.enemyRigidBody.velocity = projectedVelocity;

            }

            else if (enemyManager.distancefromTarget <= enemyManager.stoppingDistance )
            {
                enemyManager.movement = 0;
                enemyManager.enemySpeed = 0;
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0, 0);
        
                enemyManager.isPerformingAction = true;
                enemyManager.currentRecoveryTime = 3;
                if (rotations >= 2 )
                {
                    pivotCounter = Random.Range(3, 6);
                }
                NextPivot();

                
                return idleState;


            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        HandleRotateTowardsTarget(enemyManager);
        enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity;
        //Si esta en rango de ataque, atacar
        if (playerfinder && !escapeState.escape)
        {
            enemyManager.enemySpeed = 0;
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
            enemyManager.isPerformingAction = true;
            enemyManager.currentRecoveryTime = 2;
            enemyAnimatorManager.PlayTargetAnimation("Scream", true);
            pursueState.musicStarts = true;
            return pursueState;
        }
        else
        {
            return this;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
    

    public void NextPivot()
    {
        switch (currentArea)
        {
            case 1:
                switch (pivotCounter)
                {
                    case 1:
                        currentPivot = A1Pivots[0];
                        pivotCounter = 2;
                        break;
                    case 2:
                        currentPivot = A1Pivots[1];
                        pivotCounter = 3;
                        break;
                    case 3:
                        currentPivot = A1Pivots[2];
                        pivotCounter = 1;
                        rotations++;
                        break;
                    case 4:

                        currentPivot = A1Pivots[3];
                        rotations = 0;
                        pivotCounter = 1;
                        break;
                    case 5:
                        currentPivot = A1Pivots[4];
                        rotations = 0;
                        pivotCounter = 1;
                        break;
                    default: break;
                }

                break;
            case 2:
                switch (pivotCounter)
                {
                    case 1:
                        currentPivot = A2Pivots[0];
                        pivotCounter = 2;
                        break;
                    case 2:
                        currentPivot = A2Pivots[1];
                        pivotCounter = 3;
                        break;
                    case 3:
                        currentPivot = A2Pivots[2];
                        pivotCounter = 1;
                        rotations++;
                        break;
                    case 4:
                        currentPivot = A2Pivots[3];
                        rotations = 0;
                        pivotCounter = 1;
                        break;
                    case 5:
                        currentPivot = A2Pivots[4];
                        rotations = 0;
                        pivotCounter = 1;
                        break;
                    default: break;
                }
                
                break;
            case 3:
                switch (pivotCounter)
                {
                    case 1:
                        currentPivot = A3Pivots[0];
                        pivotCounter = 2;
                        break;
                    case 2:
                        currentPivot = A3Pivots[1];
                        pivotCounter = 3;
                        break;
                    case 3:
                        currentPivot = A3Pivots[2];
                        pivotCounter = 1;
                        rotations++;
                        break;
                    case 4:
                        currentPivot = A3Pivots[3];
                        rotations = 0;
                        pivotCounter = 1;
                        break;
                    case 5:
                        currentPivot = A3Pivots[4];
                        rotations = 0;
                        pivotCounter = 1;
                        break;
                    default: break;
                }
                
                break;
            case 4:
                switch (pivotCounter)
                {
                    case 1:
                        currentPivot = A4Pivots[0];
                        pivotCounter = 1;
                        break;
                    case 2:
                        currentPivot = A4Pivots[0];
                        pivotCounter = 2;
                        break;
                    case 3:
                        currentPivot = A4Pivots[0];
                        pivotCounter = 3;
                        break;
                    case 4:
                        currentPivot = A4Pivots[0];
                        pivotCounter = 1;
                        break;
                    case 5:
                        currentPivot = A4Pivots[0];
                        pivotCounter = 1;
                        break;
                } 

                break;
            default: break;

        }
        
    }


  
    public void HandleRotateTowardsTarget(EnemyManager enemyManager)
    {
        //Rotacion Manual
        if (enemyManager.isPerformingAction)
        {
            Vector3 direction = currentPivot.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
        //Rotacion NavMesh
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(enemyManager.navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyManager.enemyRigidBody.velocity;

            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.SetDestination(currentPivot.transform.position);
            enemyManager.enemyRigidBody.velocity = targetVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
        }

    }
}
