using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler inputHandler;
    Animator anim;
    public bool combo;
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHandler.isInteracting = anim.GetBool("isInteracting");
        combo = anim.GetBool("Combo");
        inputHandler.rollFlag = false;
        inputHandler.LAttack_Input = false;
        inputHandler.HAttack_Input = false;
        


    }

}
