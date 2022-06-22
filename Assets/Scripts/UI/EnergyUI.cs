using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyUI : MonoBehaviour
{
    public Slider slider; 
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxEnergyhUI(float energy)
    {
        slider.maxValue = energy;
        slider.value =energy;
        fill.color = gradient.Evaluate(1f);
        // slider değerini maksimum enerjiye eşitler
    }
    public void SetEnergyUI(float energy)
    {
        slider.value = energy;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        // slider değerini mevcut enerjiye eşitler
    }

    
}
