using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer render in this.GetComponentsInChildren(typeof(Renderer)))
        {
            render.enabled = false;
        }
    }


}
