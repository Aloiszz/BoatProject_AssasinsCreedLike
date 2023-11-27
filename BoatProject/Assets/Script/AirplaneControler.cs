using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneControler : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 6;
    [SerializeField] private float angleToOriantation = 45;
    public float linearDragDeceleration;
    public float linearDragMultiplier;

    private bool isMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    
    
    void Move()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Fire3")).normalized; 
        rb.AddRelativeForce(speed * move);
        
        if (rb.velocity.z > 1 || rb.velocity.z < -1)
        {
            transform.Rotate(-Vector3.forward, angleToOriantation * Input.GetAxis("Horizontal") * Time.deltaTime);
            transform.Rotate(Vector3.up, angleToOriantation/2 * Input.GetAxis("Horizontal") * Time.deltaTime);

            
            transform.Rotate(new Vector3(Input.GetAxis("Vertical"),0), angleToOriantation* Time.deltaTime);
            
            //transform.Rotate(Vector3.up, angleToOriantation * Input.GetAxis("Vertical") * Time.deltaTime);
        }
    }
}
