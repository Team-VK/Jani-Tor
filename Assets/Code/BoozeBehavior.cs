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
    private void OnCollisionStay(Collision col)
    {
        Rigidbody collidingObject = col.rigidbody;
        Debug.Log("Booze bottle colliding with: " + collidingObject.gameObject.tag);
        if (collidingObject.gameObject.tag.Equals("Player") ||
            collidingObject.gameObject.tag.Equals("Tool") ||
            collidingObject.gameObject.tag.Equals("Bone"))
        {
            GameObject player = GameObject.Find("Pelaaja");
            Player playerScript = player.GetComponent<Player>();
            playerScript.currentStamina += 30;
            playerScript.maxStamina -= 15;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Rigidbody collidingObject = col.rigidbody;
        Debug.Log("Booze bottle colliding with: "+collidingObject.gameObject.tag);
        if (collidingObject.gameObject.tag.Equals("Player") ||
            collidingObject.gameObject.tag.Equals("Tool") ||
            collidingObject.gameObject.tag.Equals("Bone"))
        {
            GameObject player = GameObject.Find("Pelaaja");
            Player playerScript = player.GetComponent<Player>();
            playerScript.currentStamina += 30;
            playerScript.maxStamina -= 15;
            Destroy(this.gameObject);
        }

    }
}
