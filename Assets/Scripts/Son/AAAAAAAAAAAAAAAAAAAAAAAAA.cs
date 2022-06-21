using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AAAAAAAAAAAAAAAAAAAAAAAAA : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject WheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
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

    private void Start()
    {
        carRb = GetComponent<Rigidbody>(); // başlangıçta carRB'yi arabanın rigidbodysine eşitler
        carRb.centerOfMass = _centerOfMass; // carRbnin. ağırlık merkezini kendi oluşturduğumuz referansa eşitler
        
    }

    private void Update()
    {
        GetInputs();
        AnimationWheels();
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                carRb.AddForce(transform.forward*nosPower);
            }
            else
            {
                wheel.wheelCollider.motorTorque = moveInput *600* maxAccleration * Time.deltaTime;
            }
            
        }
    }

    void Steer() // tekerlerin dönüşü ve arabanın dönüşünü ayarlar
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensivity  * maxSteerAngle;
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
}
