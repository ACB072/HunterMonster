using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : State
{


    public bool escape = false;
    public PatrolState patrolState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        Vector3 targetDirection = patrolState.currentPivot.transform.position - transform.position;
        enemyManager.distancefromTarget = Vector3.Distance(patrolState.currentPivot.transform.position, transform.position);
        enemyManager.viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        patrolState.playerfinder = false;
        enemyManager.currentTarget = null;
        //Si hace una accion

        patrolState.pivotCounter = Random.Range(4, 5); ;
                patrolState.NextPivot();
                targetDirection.Normalize();
                targetDirection.y = 0;


                enemyAnimatorManager.anim.SetFloat("Vertical", 0.5f, 0.1f, Time.deltaTime);

                enemyManager.enemySpeed = 8;
                targetDirection *= enemyManager.enemySpeed;


                Vector3 projectedVelocity = Vector3.ProjectOnPlane(targetDirection, Vector3.up);
                enemyManager.enemyRigidBody.velocity = projectedVelocity;





        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        patrolState.HandleRotateTowardsTarget(enemyManager);
        enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity;
        if (enemyManager.distancefromTarget >= 20)
        {

            return patrolState;




        }
        return this;
    }

}