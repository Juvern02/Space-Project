using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public Slider slider;


    public void SetMaxHealth(float Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
    }
    public void damageUnit(float damage)
    {
        if(slider.value > 0) { slider.value -= damage; }
    }
}
