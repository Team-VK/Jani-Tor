﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class promilleHandler : MonoBehaviour
{
    GameObject player;
    Player playerScript;
    public float promilleMax = 100.00f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pelaaja");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       this.GetComponent<Slider>().value = playerScript.currentPromille;
    }
}
