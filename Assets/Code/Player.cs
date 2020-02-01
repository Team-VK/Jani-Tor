﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rigid;
    public float speed = 1000.0f;
    public float rotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        maybeQuit();
        Vector3 movementVector = getMovementVector();
        handleMovemenent(movementVector);
        handleRotation(movementVector);
    }

    void handleMovemenent(Vector3 movement) 
    {
        rigid.AddForce(movement);
    }

    void handleRotation(Vector3 movement) 
    {
        
        float rotationStep = rotateSpeed * Time.deltaTime;
        Vector3 targetDirection =  movement - transform.position;
        Vector3 dir = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        Debug.Log("Movement: " + movement + " rotation: " + transform.rotation);
    }

    Vector3 getMovementVector() 
    {
        float delta = Time.deltaTime;
        float xAxisValue = Input.GetAxis("Horizontal") * speed * delta;
        float zAxisValue = Input.GetAxis("Vertical") * speed * delta;
        Debug.Log("Input values: " + xAxisValue + " " + zAxisValue);
        return new Vector3(xAxisValue, 1.0f, zAxisValue);;
    }

    void maybeQuit() 
    {
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
    }
}
