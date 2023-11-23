using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAnimatorManager : MonoBehaviour
{
    public Animator anim;
 

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnimation, 0.2f);
    }



}
