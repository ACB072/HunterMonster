using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDamageColliders : MonoBehaviour
{
    public BoxCollider damageCollider1;
    public BoxCollider damageCollider2;
    public BoxCollider damageCollider3;
    public void OpenEnemyCollider()
    {
        damageCollider1.enabled = true;
        damageCollider2.enabled = true;

    }
    public void CloseEnemyCollider()
    {
        damageCollider1.enabled = false;
        damageCollider2.enabled = false;

    }
    public void OpenEnemyBeakCollider()
    {
        damageCollider3.enabled = true;
   

    }
    public void CloseEnemyBeakCollider()
    {
        damageCollider3.enabled = false;
    

    }
}



