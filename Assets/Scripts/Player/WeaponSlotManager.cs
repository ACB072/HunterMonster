using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{

    WeaponHolderSpot backSpot;
    WeaponHolderSpot rightHandSpot;
    DamageCollider damageCollider;
    AnimatorHandler animator;
    PlayerLocomotion locomotion;
    PlayerStats playerStats;
    private void Awake()
    {
        locomotion = GetComponentInParent<PlayerLocomotion>();
        playerStats = GetComponentInParent<PlayerStats>();
        animator = GetComponent<AnimatorHandler>();
        WeaponHolderSpot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSpot>();
        foreach (WeaponHolderSpot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isBackSLot)
            {
                backSpot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSLot)
            {
                rightHandSpot = weaponSlot;
            }
        }
    }
    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isBack) 
    {
        if(isBack){
            backSpot.LoadWeaponModel(weaponItem);
        }
        else
        {
            rightHandSpot.LoadWeaponModel(weaponItem);
            LoadDamageCollider();
        }

    }
    public void UnloadBackWeapon()
    {
        backSpot.UnloadWapon();
        
    }
    public void UnloadRightWeapon()
    {
        rightHandSpot.UnloadWapon();

    }
    public void LoadBackWeapon()
    {
        backSpot.LoadWapon();

    }
    public void LoadRightWeapon()
    {
        rightHandSpot.LoadWapon();
       

    }

    public void LoadDamageCollider()
    {
        damageCollider = rightHandSpot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }
    public void OpenRightWeaponCollider()
    {
        damageCollider.EnableDamageCollider();
    }
    public void CloseRightWeaponCollider()
    {
        damageCollider.DisableDamageCollider();
    }

    public void combatState()
    {
        if (locomotion.animatorHandler.anim.GetBool("isCombat"))
        {
            locomotion.animatorHandler.anim.SetBool("isCombat", false);
            locomotion.inputHandler.combatFlag = false;
        }
        else
        {
            locomotion.animatorHandler.anim.SetBool("isCombat", true);
            locomotion.inputHandler.combatFlag = true;
        }
    }
    public void CloseDamage()
    {
        playerStats.notDead=false;

    }
    public void OpenDamage()
    {
        playerStats.notDead = true;
    }

}

