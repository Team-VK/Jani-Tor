using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rigid;
    public float speed = 1000.0f;
    public float rotateSpeed = 5.0f;
    public float staminaRegenRate = 0.1f;
    public float staminaBleedRate = 0.05f;
    public float progressSpeed = 1.0f;
    public float currentStamina = 100.0f;
    public float currentPromille = 0.0f;
    public float currentProgress = 0.0f;
    public float maxStamina = 100f;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        maybeQuit();
        Vector3 movementVector = getMovementVector();
        handleMovemenent(movementVector);
        handleRotation(movementVector);
        currentStamina -= staminaBleedRate * delta;
        actionProgress(progressSpeed);
    }

    void actionProgress(float progressSpeed){
        if (Input.GetKey("space")){
            currentProgress += progressSpeed;
        }
    }
    
    void handleMovemenent(Vector3 movement) 
    {
        rigid.AddForce(movement);
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z); ;
    }

    void handleRotation(Vector3 movement) 
    {
        float rotationStep = rotateSpeed * Time.deltaTime;
        Vector3 targetDirection =  movement - transform.position;
        if (Input.anyKey)
        {
            dir = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0f);
        }
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    Vector3 getMovementVector() 
    {
        float delta = Time.deltaTime;
        float xAxisValue = Input.GetAxis("Horizontal") * speed * delta;
        float zAxisValue = Input.GetAxis("Vertical") * speed * delta;
        return new Vector3(xAxisValue, 1.25f, zAxisValue);;
    }

    void maybeQuit() 
    {
        if (Input.GetKey ("escape")) 
        {
            Application.Quit();
        }
    }

    void regenerateStamina(float rate)
    {
        float delta = Time.deltaTime;
        currentStamina += rate * delta;
        currentStamina = (currentStamina > 100f) ? 100f : currentStamina;
        Debug.Log("Regenerating " + currentStamina);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Talli"))
        {
            Debug.Log("Collision with talli");
            regenerateStamina(staminaRegenRate);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}
