using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    private Camera cam;

    private void Awake() 
    {
        cam = Camera.main;   
    }

    private void LateUpdate() 
    {
        transform.LookAt(transform.position + cam.gameObject.transform.forward);
    }

}
