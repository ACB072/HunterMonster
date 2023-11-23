using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public float currentRecoveryTime=0;
    public float prueba = 10000;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    public void SetCurrentStamina()
    {
        slider.value +=1;
    
    }
    public void DrainStamina(int tired)
    {
        slider.value -= tired;
        HandleRecoveryTimer();
    }
    public void HandleRecoveryTimer()
    {
        if (currentRecoveryTime > 0)
        {
          
            currentRecoveryTime -= Time.deltaTime;
        }


    }
    private void Update()
    {
        HandleRecoveryTimer();
    }
}
