using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   


    public float mouseSensivty = 100f;
    public Transform playerTransform;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivty *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivty *Time.deltaTime;

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerTransform.Rotate(Vector3.up*mouseX);


    }
}
