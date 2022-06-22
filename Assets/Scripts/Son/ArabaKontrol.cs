using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArabaKontrol : MonoBehaviour
{
    public enum Axel
    {
        Front, // ön 
        Rear // arka
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject WheelModel; // teker model
        public WheelCollider wheelCollider; // teker collider
        public Axel axel; // enum
    }

    public float maxAccleration = 30.0f; // maximum hız
    public float nosPower = 100f; // nitro gücü
    public float breakAccleraiton = 50.0f; // fren gücü

    public float turnSensivity = 1.0f; // dönüş hassasiyeti
    public float maxSteerAngle = 30.0f; // maks teker açısı

    public Vector3 _centerOfMass; // ağırlık merkezi

    public List<Wheel> wheels; // tekerlek listesi

    float moveInput; // hareket tuşları ref
    float steerInput; // dönüş (Tekerler) tuşları ref

    private Rigidbody carRb; // arabanın rigidbodysi
    public ParticleSystem exhoust;
    public ParticleSystem nitro;
    public EnergyUI energyUI;
    public TrailRenderer trailRenderer1;
    public TrailRenderer trailRenderer2;

    private void Start()
    {
        CarStats.instance.currnetEnergy = CarStats.instance.maxEnergy; // mevcut enerjiyi maksimum enerjiye eştiler
        carRb = GetComponent<Rigidbody>(); // başlangıçta carRB'yi arabanın rigidbodysine eşitler
        carRb.centerOfMass = _centerOfMass; // carRbnin. ağırlık merkezini kendi oluşturduğumuz referansa eşitler
        energyUI.SetMaxEnergyhUI(CarStats.instance.maxEnergy); // UI için sliderın mevcut enerjiyi maks enerjiye ayarlar


    }

    private void Update()
    {
        GetInputs();
        AnimationWheels();
        particles();
        
    }
    private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }
    void GetInputs()
    {

        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move() //Kontrol tuşlarını ile hareketi sağlayan kısım
    {
        foreach (var wheel in wheels)
        {
            if (Input.GetKey(KeyCode.LeftShift) && CarStats.instance.currnetEnergy > 0)
            {
                carRb.AddForce(transform.forward * nosPower);
                CarStats.instance.SetCarEnergy(-1 * Time.deltaTime * 10);
            }
            else
            {
                wheel.wheelCollider.motorTorque = moveInput * 600 * maxAccleration * Time.deltaTime;
            }

        }
    }

    void Steer() // tekerlerin dönüşü ve arabanın dönüşünü ayarlar
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake() // fren 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * breakAccleraiton * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimationWheels() // tekerleklerin animasyonu
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;

            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.WheelModel.transform.position = pos;
            wheel.WheelModel.transform.rotation = rot;
        }
    }

    
    void particles() //particle effect kontrolleri
    {

        if (Input.GetKey(KeyCode.LeftShift) && CarStats.instance.currnetEnergy>0)
        {
            
            nitro.Play();
            exhoust.Stop();
            trailRenderer1.enabled = true;
            trailRenderer2.enabled = true;
        }
        else
        {
            nitro.Stop();
            exhoust.Play();
            trailRenderer1.enabled = false;
            trailRenderer2.enabled = false;
        }


    }
}
