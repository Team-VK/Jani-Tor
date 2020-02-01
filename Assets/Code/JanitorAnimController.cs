using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorAnimController : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("down"))
        {
            animator.Play("Walk");
        }

        if (Input.GetKey("space"))
        {
            animator.Play("Swing");
        }

        if (!Input.GetKey("up") && !Input.GetKey("space") && !Input.GetKey("down"))
        {
            animator.Play("Idle");
        }
        
    }
}
