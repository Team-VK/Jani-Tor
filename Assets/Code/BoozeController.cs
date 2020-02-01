using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoozeController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> spawnpoints;
    public GameObject boozebottle;

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
        int booze_rng = Random.Range(0, 10000);
        if (booze_rng <= 100)
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
