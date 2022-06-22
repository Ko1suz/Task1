using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public class UmarimSonKontrolcu : MonoBehaviour
{

    [SerializeField] private float maxAcceleration = 20.0f; // max hiz
    [SerializeField] private float turnSensitivity = 1.0f; // dönüş hassasiyeti
    [SerializeField] private float maxSteerAngle = 45.0f;  // maks teker açısı
    [SerializeField] private Vector3 _centerOfMass;  //Kütle merkezi
    [SerializeField] private List<Wheel> wheels; //Teker dizisi

    private float inputX, inputY;
    public float nos = 1;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = _centerOfMass;
    }


    private void Update()
    {
        AnimateWheels();
        GetInputs();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(this.gameObject.transform.forward * nos, ForceMode.Impulse);
        }
    }

    private void LateUpdate()
    {
        Move();
        Turn();


    }

    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }
    }

    private void Turn()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
            }
        }
    }

    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }
}