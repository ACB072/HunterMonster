using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTarget : State
{
    public CombatState combatState;
    public PatrolState patrolState;
    public EscapeState escapeState;
    public AudioClip combatSong;
    public AudioSource audioSource;
    public bool musicStarts;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (musicStarts)
        {
            audioSource.clip = combatSong;
            audioSource.Play();
            musicStarts = false;

        }
        //Perseguir al objetivo
        enemyStats.DrainStamina();
        if (enemyStats.currentStamina <= 0)
        {
            escapeState.escape=true;
        }
        if (enemyManager.isPerformingAction)
            return this;

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        enemyManager.distancefromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);
        enemyManager.viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        //Si hace una accion


        if (enemyManager.isPerformingAction)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            enemyManager.navMeshAgent.enabled = false;
        }
        else
        {
            if (enemyManager.distancefromTarget > enemyManager.stoppingDistance)
            {
                targetDirection.Normalize();
                targetDirection.y = 0;
                if (enemyManager.distancefromTarget >= 6)
                {
                    if (enemyManager.movement <= 1)
                    {
                        enemyAnimatorManager.anim.SetFloat("Vertical", enemyManager.movement += 0.01f, 0.1f, Time.deltaTime);
                        if (enemyManager.movement == enemyManager.maxMovement)
                        {
                            enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                        }

                    }

                    enemyManager.enemySpeed = 6;
                    targetDirection *= enemyManager.enemySpeed;
                }
                else if (enemyManager.distancefromTarget <= 6 && enemyManager.distancefromTarget >= 2.5f)
                {


                    if (enemyManager.movement > 0.5f)
                    {

                        enemyAnimatorManager.anim.SetFloat("Vertical", enemyManager.movement -= 0.01f, 0.1f, Time.deltaTime);
                    }
                    else if (enemyManager.movement <= 0.5f)
                    {

                        enemyAnimatorManager.anim.SetFloat("Vertical", enemyManager.movement += 0.01f, 0.1f, Time.deltaTime);
                    }
                    enemyManager.enemySpeed = 4;
                    targetDirection *= enemyManager.enemySpeed;


                }

                Vector3 projectedVelocity = Vector3.ProjectOnPlane(targetDirection, Vector3.up);
                enemyManager.enemyRigidBody.velocity = projectedVelocity;

            }

            else if (enemyManager.distancefromTarget <= enemyManager.stoppingDistance || enemyManager.isPerformingAction)
            {
                
                enemyManager.movement = 0;
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0, 0);


            }
             if (enemyManager.distancefromTarget >= 20)
            {
                patrolState.playerfinder = false;
                enemyManager.currentTarget = null;
                patrolState.peaceMusicStarts = true;
                return patrolState;

               


            }

        }
        
        
        
        //WTF is this
        /*
        if (enemyManager.distancefromTarget > enemyManager.maximunAttackRange)
        {

            enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);

            targetDirection.Normalize();
            targetDirection.y = 0;

            float speed = 3;
            targetDirection *= speed;
            Vector3 projectedVelocity = Vector3.ProjectOnPlane(targetDirection, Vector3.up);
            enemyManager.enemyRigidBody.velocity = projectedVelocity;
        }*/

  
        HandleRotateTowardsTarget(enemyManager);
        enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity;
        //Si esta en rango de ataque, atacar
        if (escapeState.escape)
        {
            return escapeState;
        }
        if (enemyManager.distancefromTarget <= enemyManager.maximunAttackRange)
        {
            return combatState;
        }
        
        else
        {
            return this;
        }
        
        
    }
    private void HandleRotateTowardsTarget(EnemyManager enemyManager)
    {
        //Rotacion Manual
        if (enemyManager.isPerformingAction)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
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
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            enemyManager.enemyRigidBody.velocity = targetVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
        }

    }
}
