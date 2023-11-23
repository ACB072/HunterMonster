using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    public AttackState attackState;
    public PursueTarget pursueTarget;
    public EscapeState escapeState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {

        enemyStats.DrainStamina();
        if (enemyStats.currentStamina <= 0)
        {
            escapeState.escape = true;
        }
        //Comprobar alcance de ataque
        enemyManager.distancefromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        //Potencialmente rodear al jugador
        //Si esta en rango, devolver un estado de ataque
        if(enemyManager.currentRecoveryTime<=0 && enemyManager.distancefromTarget <= enemyManager.maximunAttackRange )
        {
            return attackState;
        } else if (enemyManager.distancefromTarget>enemyManager.maximunAttackRange)
        {
            enemyManager.stoppingDistance = 2.5f;
            enemyManager.maximunAttackRange = 2.5f;
            return pursueTarget;
        }else if (escapeState.escape)
        {
            return escapeState;
        }
        //Si el jugador huye
        return this;
    }
}
