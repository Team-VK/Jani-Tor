using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBehavior : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision col)
    {
        Debug.Log("Tool collision detected");

        if (col.gameObject.tag.Equals("Bush"))
        {

            Debug.Log("Tool colliding with bush");

        }

    }


    }
