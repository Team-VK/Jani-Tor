using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraBehaviour : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 playercurrentpos = player.transform.position;
        Vector3 newpos = new Vector3(playercurrentpos.x, playercurrentpos.y + offset.y, playercurrentpos.z);
        transform.position = newpos;
    }

    Vector3 getDirectionVector3()
    {
        float delta = Time.deltaTime;
        float xAxisValue = player.transform.rotation.x;
        float yAxisValue = player.transform.rotation.y;
        float zAxisValue = player.transform.rotation.z;
        return new Vector3(xAxisValue, 0.0f, zAxisValue);
    }

}
