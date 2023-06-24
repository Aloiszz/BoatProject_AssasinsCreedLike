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

    public GameObject rightTireRaycast;
    public GameObject leftTireRaycast;
    public bool rightTireOnGround;
    public bool leftTireOnGround;

    private bool isMoving;
    private float turnEffetor = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (leftTireRaycast && rightTireRaycast)
        {
            Move();
        }
        rb.drag = linearDragDeceleration * linearDragMultiplier;
    }
    
    void Update()
    {
        Ray rigthRay = new Ray(rightTireRaycast.transform.position, -transform.up);
        RaycastHit hitDataRight;
        if (Physics.Raycast(rigthRay, out hitDataRight, 1)) // right ray 
        {
            if (hitDataRight.collider.CompareTag("Ground"))
            {
                Debug.DrawRay(rightTireRaycast.transform.position, -transform.up, Color.green);
                rightTireOnGround = true;
            }
            else
            {
                Debug.DrawRay(rightTireRaycast.transform.position, -transform.up, Color.red);
                rightTireOnGround = false;
            }
        }
        
        Ray leftRay = new Ray(leftTireRaycast.transform.position, -transform.up);
        RaycastHit hitDataLeft;
        if (Physics.Raycast(leftRay, out hitDataLeft, 1)) // left ray 
        {
            if (hitDataLeft.collider.CompareTag("Ground"))
            {
                Debug.DrawRay(leftTireRaycast.transform.position, -transform.up, Color.green);
                leftTireOnGround = true;
            }
            else
            {
                Debug.DrawRay(leftTireRaycast.transform.position, -transform.up, Color.red);
                leftTireOnGround = false;
            }
        }
    }

    void Move()
    {
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized; 
        
        rb.AddRelativeForce(speed * move);
        Debug.Log((float)move.x + " " + (float)move.z);

        if (rb.velocity.z > 1 || rb.velocity.z < -1)
        {
            turnEffetor = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(turnEffetor, 0,0)), timeToOrientate);
            isMoving = true;
        }
        else
        {
            isMoving = false;
            //turnEffetor = 0;
        }
    }
}
