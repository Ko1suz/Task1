using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabaKontrolcusu : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float turnSpeed;
    public bool forward;
    public bool backward;
    public bool left;
    public bool right;

    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (forward)
        {
            rb.AddForce(this.gameObject.transform.forward*speed,ForceMode.Force);
            
        }
        else if (backward)
        {
            rb.AddForce(this.gameObject.transform.forward*-speed,ForceMode.Force);
        }


        rb.AddTorque(0,y*turnSpeed*rb.velocity.z,0);
        // if (left)
        // {
        //     rb.AddTorque(this.gameObject.transform.localEulerAngles*-turnSpeed);
        // }
        // else if (right)
        // {
        //      rb.AddTorque(this.gameObject.transform.localEulerAngles*turnSpeed);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        z =  Input.GetAxis("Vertical");
        y =  Input.GetAxis("Horizontal");
        forward = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        backward = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
        left = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        right = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
    }
}
