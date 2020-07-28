using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float throwForce = 10f;
    public GameObject throwObjPrefab;
    Camera FPSCamera;
    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject apple = Instantiate(throwObjPrefab, transform.position, Quaternion.identity);
        apple.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * throwForce, ForceMode.Impulse);
    }
}
