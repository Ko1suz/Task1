using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    public static CarStats instance;
    public EnergyUI energyUI;

    private void Awake() {
        instance = this;
    }

    public float maxEnergy = 100;
    private float _currnetEnergy;

    public float currnetEnergy
    {
        get { return _currnetEnergy; }
        set { _currnetEnergy = Mathf.Clamp(value, 0, maxEnergy); }
    }

    public void SetCarEnergy(float value)
    {
        CarStats.instance.currnetEnergy += value;
        energyUI.SetEnergyUI(CarStats.instance.currnetEnergy);
        //Debug.LogWarning(value + " Kadar enerji kaybettin");

    }
}
