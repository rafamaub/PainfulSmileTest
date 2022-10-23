using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRb;

    [Header("Input")]
    public bool moving;
    public bool turnRight;
    public bool turnLeft;

    [Header("Ship Stats")]
    [SerializeField] float shipAcceleration;
    [SerializeField] float shipRotationSpeed;

    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        if (moving)
        {
            Accelerate();
        }

        if (turnRight)
        {
            RotateRight();
        }

        if (turnLeft)
        {
            RotateLeft();
        }
    }

    public void RotateLeft()
    {
        myRb.AddTorque(-shipRotationSpeed * Time.deltaTime * 10f);
    }

    public void RotateRight()
    {
        myRb.AddTorque(shipRotationSpeed * Time.deltaTime * 10f);
    }

    public void Accelerate()
    {
        myRb.AddForce(transform.up * shipAcceleration * 10f * Time.deltaTime, ForceMode2D.Force);
    }
}
