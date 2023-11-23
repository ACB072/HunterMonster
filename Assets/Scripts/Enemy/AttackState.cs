using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public State combatState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyManager.stoppingDistance = 0.9f;
        enemyManager.maximunAttackRange = 0.9f;
        enemyStats.DrainStamina();
        //Seleccionar Ataque
        //Si el ataque usado no cumple el rango, cambiar a otro ataque
        //Si si puede hacer el ataque, atacar y detener el movimiento
        //tiempo de recuperacion
        #region Attacks
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        enemyManager.distancefromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);
        enemyManager.viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        if (enemyManager.isPerformingAction)
        {
            return combatState;
        }
       
        if (currentAttack != null)
        {
            if (enemyManager.distancefromTarget< currentAttack.minDistancetoAttack)
            {
                return this;
            }else if(enemyManager.distancefromTarget < currentAttack.maxDistancetoAttack)
            {
                if (enemyManager.viewableAngle <= currentAttack.maximunAttackAngle && enemyManager.viewableAngle >= currentAttack.minimunAttackAngle)
                {
                    if (enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction==false)
                    {
                        enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                        enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
                        enemyManager.isPerformingAction = true;
                        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
                        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation,true);
                        currentAttack = null;
                        return combatState;
                    }
                }
            }
        }
        else
        {
            GetNewAttack(enemyManager);
        }
        return combatState;
        /*if (currentAttack == null)
        {
            GetNewAttack(enemyManager);
        }
        else
        {
            enemyManager.isPerformingAction = true;
            enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
            enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
            currentAttack = null;
        }
        
        
        return this;*/
        #endregion
    }
    private void GetNewAttack(EnemyManager enemyManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        enemyManager.distancefromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

        int maxScore = 0;
        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (enemyManager.distancefromTarget <= enemyAttackAction.maxDistancetoAttack && enemyManager.distancefromTarget >= enemyAttackAction.minDistancetoAttack)
            {
                if (viewableAngle >= enemyAttackAction.minimunAttackAngle && viewableAngle <= enemyAttackAction.maximunAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }
            }
        }
        int randomValue = Random.Range(0, maxScore);
        int temporaryScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (enemyManager.distancefromTarget <= enemyAttackAction.maxDistancetoAttack && enemyManager.distancefromTarget >= enemyAttackAction.minDistancetoAttack)
            {
                if (viewableAngle >= enemyAttackAction.minimunAttackAngle && viewableAngle <= enemyAttackAction.maximunAttackAngle)
                {
                    if (currentAttack != null)

                        return;

                    temporaryScore += enemyAttackAction.attackScore;
                    if (temporaryScore > randomValue)
                    {
                        currentAttack = enemyAttackAction;
                    }
                }
            }
        }

    }
}