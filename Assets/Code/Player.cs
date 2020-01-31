using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rigid;
    public float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Debug.Log("############# " + x + " " + y);
        Vector3 move = new Vector3(x, 0f, y);
        rigid.AddForce(move * speed);
    }
}
