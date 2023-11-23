using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    
    public HealthBar healthBar;
    public StaminaBar staminaBAr;
    public AnimatorHandler animatorHandler;
    public PlayerLocomotion playerLocomotion;
    public PlayerManager playerManager;
    public Transparency transparency;

    public bool notDead;
    public void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerManager = GetComponent<PlayerManager>();
    }
    private void Start()
    {
       
        currentHealth = 100;
        
        notDead = true;
        
    }
    private void Update()
    {
        if (staminaBAr.currentRecoveryTime <= 0)
        {
            
            staminaBAr.SetCurrentStamina();

        }
    }

    public void TakeDamage(int damage)
    {

        if (notDead)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetCurrentHealth(currentHealth);
            animatorHandler.PlayTargetAnimation("Damage", true);
        }
       

        if (currentHealth <= 0)
        {
            notDead = false;
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Death", true);
            //HandlePlayer death
            transparency.scene = "MissionFailed";
            transparency.newScene = true;
        

         
            playerLocomotion.enabled = false;
            playerManager.enabled = false;
            this.enabled = false;


        }
            
        }
}

