using System.Collections;
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
        Debug.Log(movementVector);
        handleRotation(movementVector);
        handleMovemenent(movementVector);
    }

    void handleMovemenent(Vector3 movement) 
    {
        rigid.AddForce(movement);
    }

    void handleRotation(Vector3 movement) 
    {
        // Do not rotate player if there is no movement
        if (movement != Vector3.zero) 
        {
            Vector3 targetDirection =  movement - transform.position;
            float singleStep = rotateSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
        }
    }

    Vector3 getMovementVector() 
    {
        float delta = Time.deltaTime;
        float xAxisValue = Input.GetAxis("Horizontal") * speed * delta;
        float zAxisValue = Input.GetAxis("Vertical") * speed * delta;
        return new Vector3(xAxisValue, 0.0f, zAxisValue);
    }

    void maybeQuit() 
    {
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
    }
}
