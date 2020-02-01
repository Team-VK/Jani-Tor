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
        if (Input.GetKeyDown("up"))
        {
            animator.Play("Walk");
        }

        if (Input.GetKeyDown("space"))
        {
            animator.Play("Swing");
        }

        if (!Input.GetKey("up") && !Input.GetKey("space"))
        {
            animator.Play("Idle");
        }
        
    }
}
