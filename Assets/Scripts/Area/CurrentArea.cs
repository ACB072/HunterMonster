using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentArea : MonoBehaviour
{
    public PatrolState patrolState;
    public int area;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Hittable")
        {
            patrolState.currentArea = area;

            
        }
    
    }
}
