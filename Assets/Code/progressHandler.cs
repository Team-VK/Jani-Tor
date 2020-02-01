using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressHandler : MonoBehaviour
{
    GameObject player;
    GameObject progressUI;
    Player playerScript;
    public float maxProgress = 100.00f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pelaaja");
        playerScript = player.GetComponent<Player>();
        progressUI = GameObject.Find("ProgressUI");
    }

    void Hide(){
        this.transform.parent.GetComponent<CanvasGroup>().alpha = 0;
    }

    void Show(){
        this.transform.parent.GetComponent<CanvasGroup>().alpha = 1;

    }
    // Update is called once per frame
    void Update(){
        this.GetComponent<Slider>().value = playerScript.currentProgress;
        if (Input.GetKey("space")){
            Show();
        }
        else{
            Hide();
        }
    }
}
