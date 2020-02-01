using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoozeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody collidingObject = col.rigidbody;
        Debug.Log(collidingObject.gameObject.tag);
        if (collidingObject.gameObject.tag.Equals("Player"))
        {
            this.transform.parent.GetComponent<Player>().currentStamina += 30;
            this.transform.parent.GetComponent<Player>().maxStamina -= 15;
        }

    }
}
