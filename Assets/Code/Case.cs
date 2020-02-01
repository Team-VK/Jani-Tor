﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{

    public Transform trashcan;
    public float condition = 100;
    public bool isActive = false;

    private float time = 0f;
    //public static List<ObjectDrag> draggableList = new List<ObjectDrag>();

    // Use this for initialization
    void Start()
    {
    }

    // Cases start as inactive, they have an x% chance to become active on each tick
    // If they are active, they start decaying over time
    void Update()
    {
        int case_rng = 0;

        if (!isActive)
        {
            case_rng = Random.Range(0, 10000);
        }

        if (isActive || (!isActive && case_rng <= 5)) {
            this.isActive = true;
            time += Time.deltaTime / 1000f;  //To be used as a factor on condition decay to simulate faster decay as time passes
            this.condition -= (time * 1);
            Debug.Log("My condition:" + this.condition.ToString());
            if(this.condition <= 0)
            {
                Debug.Log("I AM DED");
                Destroy(this.gameObject);
            }
        }
        //float rnd = Random.Range(0f, 1f);
        // Odds of spawning a new case increses as the game goes on
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //        repairObject();
        //}
        //

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("GG");
        Rigidbody collidingObject = col.rigidbody;
        Debug.Log(collidingObject.gameObject.tag);
        if (collidingObject.gameObject.tag.Equals("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (isValidTool(this, collidingObject))
                {
                    repairObject();
                }
            }
        }

    }

    private void repairObject() {
        this.condition += 5;
        Debug.Log(this.condition);
    }

    private bool isValidTool(Case targetObject, Rigidbody collidingTool)
    {
        return true;
    }

}