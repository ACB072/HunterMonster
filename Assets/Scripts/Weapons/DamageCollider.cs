using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;
    public int currentDamage=25;
    public GameObject particles;
    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
       


    }
  
    public void EnableDamageCollider()
    {
        particles.SetActive(false);
        damageCollider.enabled = true;
       
    }
    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
        particles.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hittable")
        {
            EnemyStats enemyStats  = other.GetComponent<EnemyStats>();
            particles.SetActive(true);
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentDamage);
            }
        }
       

    }
}
