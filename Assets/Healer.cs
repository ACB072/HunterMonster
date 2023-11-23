using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public PlayerStats playerStats;
    private MeshRenderer meshRenderer;

    public float currentRecoveryTime=25;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (!meshRenderer.enabled)
        {
            HandleRecoveryTimer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && meshRenderer.enabled)
        {

            playerStats.currentHealth += 30;
            playerStats.healthBar.SetCurrentHealth(playerStats.currentHealth);
            if (playerStats.currentHealth >= 100)
            {
                playerStats.currentHealth = 100;
                playerStats.healthBar.SetCurrentHealth(playerStats.currentHealth);
            }
            meshRenderer.enabled = false;
            
        }
    }


    public void HandleRecoveryTimer()
    {
        if (currentRecoveryTime >= 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }
        else
        {
            currentRecoveryTime = 25;
            meshRenderer.enabled = true;
        }


    }
}

