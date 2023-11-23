using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyLocomotion : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;
    

    
   // public LayerMask detectionLayer;


   
    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();

    }

    private void Start()
    {
      
        enemyManager.enemyRigidBody.isKinematic = false;
    }
    public void HandleDetection()
    {
       /* Collider[] colliders = Physics.OverlapSphere(this.transform.position, enemyManager.detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
            if (characterStats != null )
            {
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > enemyManager.minimunDetectionAngle && viewableAngle < enemyManager.maximunDetectionAngle)
                {
                    currentTarget = characterStats;
                }
            }

        }*/
    }
    /*public void HandleMovetoTarget()
    {
        if (enemyManager.isPerformingAction)
            return;

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        distancefromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position,transform.position);
        float viewAngle = Vector3.Angle(targetDirection, transform.forward);

        //Si hace una accion
        if (enemyManager.isPerformingAction)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical",0,0.1f, Time.deltaTime);
            navMeshAgent.enabled = false;
        }
        else
        {
            if (distancefromTarget > stopingDistance)
            {

                enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);

                targetDirection.Normalize();
                targetDirection.y = 0;

                float speed = 3;
                targetDirection *= speed;
                Vector3 projectedVelocity = Vector3.ProjectOnPlane(targetDirection, Vector3.up);
                enemyRigidBody.velocity = projectedVelocity;
            }
            else if(distancefromTarget <= stopingDistance)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            }
        }
        HandleRotateTowardsTarget();
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation = Quaternion.identity;

    }*/
   /* private void HandleRotateTowardsTarget()
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
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed / Time.deltaTime);
        }
        //Rotacion NavMesh
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyManager.enemyRigidBody.velocity;

            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            enemyManager.enemyRigidBody.velocity = targetVelocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);
        }

    }*/
}
