using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/WeaponItems")]
public class WeaponItem : Item
{
    public GameObject modelPrefab;
    public bool isUnarmed;

    public string OH_Light_Attack_1;
    public string OH_Light_Attack_2;
    public string OH_Light_Attack_3;
    public string OH_Heavy_Attack_1;
    public string OH_Heavy_Attack_2;
    public string OH_Heavy_Attack_3;
}
