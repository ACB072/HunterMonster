using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlcontrol : MonoBehaviour
{
    public GameObject canvas;

    public void ActivateIt()
    {
        canvas.SetActive(true);
    }
    public void DeactivateIt()
    {
        canvas.SetActive(false);
    }




}
