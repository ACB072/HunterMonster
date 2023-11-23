using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public PursueTarget pursueState;
    public PatrolState patrolState;
    public LayerMask detectionLayer;
    public bool playerfinder = false;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        //Buscar al objetivo
        //Cambiar a perseguir al objetivo
        //sino, volver a este estado
        //Si se sale el objetivo, volver a buscarlo
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, enemyManager.detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
            if (characterStats != null && characterStats.CompareTag("Player"))
            {
                
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > enemyManager.minimunDetectionAngle && viewableAngle < enemyManager.maximunDetectionAngle)
                {
                    print("Aqui llega");
                    enemyManager.currentTarget = characterStats;
                    playerfinder = true;
                    
                }
            }

        }
        if(playerfinder)
        {
            
            return pursueState;
        }
        else  if(!playerfinder)
        {
      
            return patrolState;
        }
        else
        {
            return this;
        }
    }

}