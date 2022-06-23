using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSmoothnes;
    private float OrjMoveSmoothnes;
    public float rotSmoothnes;

    public Vector3 moveOffset;
    public Vector3 orjMoveOffset;
    public Vector3 rotOffset;

    public Transform targetCar;
    private void Start()
    {
        targetCar = FindObjectOfType<ArabaKontrol>().transform;
        orjMoveOffset = moveOffset;
        OrjMoveSmoothnes = moveSmoothnes;
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void Update()
    {
        nosCam();
    }

    void FollowTarget()
    {
        HandleMovment();
        HandleRotation();
    }
    void HandleMovment()
    {
        Vector3 targetPos = new Vector3();
        targetPos = targetCar.TransformPoint(moveOffset);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothnes * Time.deltaTime);
    }

    void HandleRotation()
    {
        var direction = targetCar.position - transform.position;
        var rotation = new Quaternion();

        rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothnes * Time.deltaTime);
    }

    void nosCam()
    {
        if (ArabaKontrol.nos)
        {
            moveSmoothnes = 5;    
            moveOffset.z = -10;   
        }
        else
        {
            moveSmoothnes = OrjMoveSmoothnes;
            moveOffset.z =  orjMoveOffset.z;
        }
    }

}
