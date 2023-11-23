using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSpot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isBackSLot;
    public bool isRightHandSLot;

    public GameObject currentWeaponModel;
    public void UnloadWapon()
    {
        currentWeaponModel.SetActive(false);
    }
    public void LoadWapon()
    {
        currentWeaponModel.SetActive(true);
    }

    public void UnloadandDestroy()
    {
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }
    }

    public  void LoadWeaponModel(WeaponItem weaponItem)
    {
        UnloadandDestroy();
        if(weaponItem == null)
        {
            return; 
        }

        GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
        if (model != null)
        {
            if (parentOverride != null)
            {
                model.transform.parent = parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }
            model.transform.localScale = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }
        currentWeaponModel = model;
    }
}
