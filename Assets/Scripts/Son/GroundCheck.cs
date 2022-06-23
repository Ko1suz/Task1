using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public static bool groundCheck;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Ground")
        {
            groundCheck = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = false;
        }
    }
}
