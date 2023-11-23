using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;
    public WeaponItem rightWeaponItem;
    public WeaponItem backtWeaponItem;
    [HideInInspector]
    public AnimatorHandler animatorHandler;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();

    }
    private void Start()
    {
        weaponSlotManager.LoadWeaponOnSlot(backtWeaponItem, true);
        weaponSlotManager.LoadWeaponOnSlot(rightWeaponItem, false);





    }
    private void Update()
    {
        if (animatorHandler.anim.GetBool("isCombat"))
        {
            weaponSlotManager.LoadRightWeapon();
            weaponSlotManager.UnloadBackWeapon();
            

        }
        else
        {
            weaponSlotManager.LoadBackWeapon();
            weaponSlotManager.UnloadRightWeapon();

        }
    }
}
