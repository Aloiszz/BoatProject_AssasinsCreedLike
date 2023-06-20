using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 6;
    [SerializeField] private float timeToOrientate = 1.2f;
    public float linearDragDeceleration;
    public float linearDragMultiplier;

    private bool isMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Move();
        
        rb.drag = linearDragDeceleration * linearDragMultiplier;
    }

    void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        rb.AddForce(speed * move);
        
        Debug.Log(Input.GetAxis("Horizontal"));
        
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), timeToOrientate);
            isMoving = true; 
        }
        else isMoving = false;
    }
}
