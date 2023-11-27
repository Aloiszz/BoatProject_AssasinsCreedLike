using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shootings : MonoBehaviour
{
    public Camera Cam;
    public GameObject ammo;
    public Transform shootingsLocation;

    public float Throwforce;
    public float throwUpawardForce;

    public GameObject PSPistolet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           var projectile = Instantiate(ammo, shootingsLocation.position, Quaternion.identity);
           Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

           Vector3 forceToAdd = Cam.transform.forward * Throwforce + transform.up * throwUpawardForce;
           
           projectileRb.AddForce(forceToAdd,ForceMode.Impulse);
           
           Destroy(projectile, 5);

           Instantiate(PSPistolet, Cam.transform.position, Quaternion.identity);
        }
    }
}
