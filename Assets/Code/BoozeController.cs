using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoozeController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> spawnpoints;
    public GameObject boozebottle;
    public int maxBottles = 5;

    void Start()
    {
        Vector3 spawnpoint1 = new Vector3(7, 1, 8);
        Vector3 spawnpoint2 = new Vector3(-30, 1, 24);
        Vector3 spawnpoint3 = new Vector3(-6, 1, 50);
        Vector3 spawnpoint4 = new Vector3(-16, 1, -40);
        Vector3 spawnpoint5 = new Vector3(-55, 1, 4);


        spawnpoints = new List<Vector3>();
        spawnpoints.Add(spawnpoint1);
        spawnpoints.Add(spawnpoint2);
        spawnpoints.Add(spawnpoint3);
        spawnpoints.Add(spawnpoint4);
        spawnpoints.Add(spawnpoint5);


    }

    // Update is called once per frame
    void Update()
    {
        int booze_rng = Random.Range(0, 10000);
        GameObject[] bottles = GameObject.FindGameObjectsWithTag("Booze");
        
        if (booze_rng <= 100 && bottles.Length < maxBottles)
        {
            spawnBooze();
        }
    }

    void spawnBooze()
    {
        int random_spawnpoint = Random.Range(0, spawnpoints.Count-1);
        Vector3 spawnpoint = spawnpoints[random_spawnpoint];
        Transform spawnedobject;
        spawnedobject = Instantiate(boozebottle.transform, spawnpoint, Quaternion.identity);
    }
}
