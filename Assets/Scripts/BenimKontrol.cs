using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenimKontrol : MonoBehaviour
{
    public Rigidbody Ballrb;
    public float forwardAccel, backwardAccel, maxSpeed, turnStrength;


    private void Update() {
        transform.position = Ballrb.transform.position;
    }
    private void FixedUpdate() {
        Ballrb.AddForce(transform.forward*forwardAccel);
    }
}
