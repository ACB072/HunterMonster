using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportTo;
    public GameObject TeleportToNest;
    public GameObject currentArea;
    public GameObject nextArea;

    public Material skybox;
    public PatrolState patrolState;
    public EnemyManager enemyManager;
    public EscapeState escapeState;
   
    public int area;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.transform.position = TeleportTo.transform.position;
            RenderSettings.skybox = skybox;
            foreach (Renderer render in currentArea.GetComponentsInChildren(typeof(Renderer)))
            {
                render.enabled = false;
            }
            foreach (Renderer render in nextArea.GetComponentsInChildren(typeof(Renderer)))
            {
                render.enabled = true;
                
            }
        }
        else if (collision.gameObject.CompareTag("Hittable"))
        {
            if (enemyManager.enemyStats.currentHealth >= 213)
            {
                collision.gameObject.transform.position = TeleportTo.transform.position;
                enemyManager.navMeshAgent.Warp(TeleportTo.transform.position);
                enemyManager.enemyStats.currentStamina = 220;
                patrolState.currentArea = area;
            }
            else
            {
                collision.gameObject.transform.position = TeleportToNest.transform.position;
                enemyManager.navMeshAgent.Warp(TeleportToNest.transform.position);
                enemyManager.enemyStats.currentStamina = 4500;
                patrolState.currentArea = 4;
            }
 
          
            escapeState.escape = false;
         
            switch (patrolState.currentArea)
            {
                case 1:
                    patrolState.currentPivot = patrolState.A1Pivots[0];
                    
                    break;
                case 2:
                    patrolState.currentPivot = patrolState.A2Pivots[0];
                    
                    break; 
                case 3:
                    patrolState.currentPivot = patrolState.A3Pivots[0];
                    
                    break;
                case 4:
                    patrolState.currentPivot = patrolState.A4Pivots[0];
                    
                    break;

            }
           
        }
    }
}
