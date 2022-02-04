using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {

        slider.value = health;
    }

    public void IncHealth(int health, int val, int maxHealth)
    {
        if (health + val < maxHealth)
        {
            health += val;
            slider.value = health;
        }
        else
            health = maxHealth;
            
    }
    

}
