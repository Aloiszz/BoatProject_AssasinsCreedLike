using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCameraBase> cameras;
    [SerializeField] private int countIncrementation;
    
    void Start()
    {
        bool ison = false;
        foreach (var j in cameras)// set all cameras to priority 8 except the first camera
        {
            if (!ison)
            {
                j.Priority = 10;
                ison = true;
            }
            else
            {
                j.Priority = 8;
            }
        }
    }
    
    void Update()
    {
        ChangeCamera();
    }

    void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.S) && countIncrementation < cameras.Count - 1) // accrémenter 
        {
            countIncrementation++;
        }
        if (Input.GetKeyDown(KeyCode.Z) && countIncrementation > 0) // décrémenter
        {
            countIncrementation--;
        }

        switch (countIncrementation)
        {
            case  0:
                cameras[0].Priority = 10;
                cameras[1].Priority = 8;
                cameras[2].Priority = 8;
                break;
            
            case 1:
                cameras[0].Priority = 8;
                cameras[1].Priority = 10;
                cameras[2].Priority = 8;
                break;
            
            case 2:
                cameras[0].Priority = 8;
                cameras[1].Priority = 8;
                cameras[2].Priority = 10;
                break;
        }
    }
}
