using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : GeneralAnimatorManager
{
    EnemyManager enemyLocomotion;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyLocomotion = GetComponentInParent<EnemyManager>(); //Cambiar a padre

    }

    public void OnAnimatorMove()
    {
        float delta = Time.deltaTime;
        enemyLocomotion.enemyRigidBody.drag = 0;
        Vector3 deltaPosition = anim.deltaPosition;
      
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        enemyLocomotion.enemyRigidBody.velocity = velocity ;
    }
}
