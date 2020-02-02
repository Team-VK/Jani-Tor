using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBehavior : MonoBehaviour
{

    public Color prefabColor = Color.green;
    public GameObject leafEffect;
    private GameObject leafEffectInstance;

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
            leafEffectInstance = GameObject.Instantiate(
                    leafEffect,
                    this.transform.position,
                    this.transform.rotation
            );
        }

    }


    }
