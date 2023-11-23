using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
   
    
    public EnemyAnimatorManager enemyAnimatorManager;
    private EnemyLocomotion enemyLocomotion;
    private EnemyManager enemyManager;
    public Camera deathCamera;
    public Transparency transparency;
    public float currentStamina = 4500;


    public void Awake()
    {
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        enemyLocomotion = GetComponent<EnemyLocomotion>();
        enemyManager = GetComponent<EnemyManager>();
       
    }
    private void Start()
    {

        currentHealth = 1420;
        

    }

    public void DrainStamina()
    {
        currentStamina -= 0.1f;
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;



        if (currentHealth <= 0)
        {
            currentHealth = 0;
            enemyAnimatorManager.anim.Play("Death");
            deathCamera.enabled = true;
            //HandlePlayer death
            transparency.scene = "MissionComplete";
            transparency.newScene = true;
            this.enabled = false;
            enemyLocomotion.enabled = false;
            enemyManager.enabled = false;

        }
    }
}
