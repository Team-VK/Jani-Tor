using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rigid;
    public float speed = 20.0f;
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
        handleMovemenent(movementVector);
        //handleRotation(movementVector);

    }

    void handleMovemenent(Vector3 movement) 
    {
        var delta = Time.deltaTime;
        Debug.Log("FORCE: " + movement);
        rigid.AddForce(movement);
        rigid.angularVelocity = Vector3.zero;
    }

    void handleRotation(Vector3 movement) 
    {
        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(movement.x, 0, movement.z);

        var rotate = Time.deltaTime * rotateSpeed;
        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotate);
    }

    Vector3 getMovementVector() 
    {
        var delta = Time.deltaTime;
        var x = 0f;
        var y = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x += transform.position.x - (speed * delta);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += transform.position.x + (speed * delta);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y += transform.position.y + (speed * delta);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y += transform.position.y - (speed * delta);
        }

        Debug.Log("" 
            + Input.GetKey(KeyCode.LeftArrow) + "-" 
            + Input.GetKey(KeyCode.RightArrow) + "-"
            + Input.GetKey(KeyCode.UpArrow) + "-"
            + Input.GetKey(KeyCode.DownArrow));

        return new Vector3(x, 0f, y);
    }

    void maybeQuit() 
    {
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
    }
}
