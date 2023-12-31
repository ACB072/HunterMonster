using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attacker : MonoBehaviour
{
    AnimatorHandler animatorHandler;
    InputHandler inputHandler;
    public string lastAttack;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        inputHandler = GetComponent<InputHandler>();

    }
    public void HandleWeaponCombo(WeaponItem weapon)
    {
        if (inputHandler.comboFlag)
        {
            animatorHandler.anim.SetBool("Combo", false);
            if (lastAttack == weapon.OH_Light_Attack_1)
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                lastAttack = weapon.OH_Light_Attack_2;

            }
            else
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_3, true);
                lastAttack = weapon.OH_Light_Attack_2;

            }
        }

    }
    public void Handle_Light_Attack(WeaponItem weapon)
    {
        animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        lastAttack = weapon.OH_Light_Attack_1;
    }
    public void Handle_Heavy_Attack()
    {
        animatorHandler.PlayTargetAnimation("Block",true);
        
    }
}
