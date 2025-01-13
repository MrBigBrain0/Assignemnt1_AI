using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    public RobotBattery robotBatter;

    public float moveSpeed = 2.5f;
    public float turnSpeed = 120f;
    public float stoppingDistance = 0.1f;

    [HideInInspector] public Transform destination;


    public void Update()
    {
        if (destination == null) return;

        Vector3 direction = destination.position - transform.position;
        Turn(direction);
        Move(direction);
    }

    private void Turn(Vector3 direction)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(direction);
        if (transform.rotation == desiredRotation) return;

        float step = turnSpeed * Time.deltaTime;
        transform.rotation = desiredRotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, step);
    }


    private void Move(Vector3 direction)
    {
        if (direction.magnitude <= stoppingDistance) return;
        transform.Translate(moveSpeed * Time.deltaTime * transform.forward, Space.World);
    }

}
