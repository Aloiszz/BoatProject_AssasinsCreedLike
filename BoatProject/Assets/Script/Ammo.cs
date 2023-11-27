using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject bomb;
    public float speed;
    public Vector3 shootingsDirection;
    private Rigidbody rb;
    void Start()
    {
        Destroy(gameObject, 5);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //rb.velocity = shootingsDirection * speed; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
