using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoozeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> spawnpoints;

    void Start()
    {
        Vector3 spawnpoint1 = new Vector3(1, 2, 3);
        Vector3 spawnpoint2 = new Vector3(1, 2, 3);
        spawnpoints = new List<Vector3>();
        spawnpoints.Add(spawnpoint1);
        spawnpoints.Add(spawnpoint2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnBooze()
    {
        int random_spawnpoint = Random.Range(0, spawnpoints.Count-1);

    }
}
