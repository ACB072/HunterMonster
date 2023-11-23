using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "A.I/Enemy Actions/Attack Action")]
public class EnemyAttackAction : EnemyActions
{
    public int attackScore = 3;
    public float recoveryTime = 2f;

    public float maximunAttackAngle = 35;
    public float minimunAttackAngle = -35;

    public float minDistancetoAttack = 0;
    public float maxDistancetoAttack = 3;
}
