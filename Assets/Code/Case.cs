using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{

    public Transform trashcan;
    public float condition = 100;
    public bool isActive = false;
    public float repairRate = 5f;
    public float scaleLimit = 50;
    public float growRate = 0.5f;
    public float growLimit = 250;

    private float time = 0f;
    private bool particlesActivated = false;

    public Color prefabColor = Color.white;

    public GameObject paskaSaastaa;
    private GameObject paskaSaastaaInstance;
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

            //Debug.Log("My condition:" + this.condition.ToString());
            if (this.condition <= 30 && !particlesActivated) {
                paskaSaastaaInstance = GameObject.Instantiate(
                        paskaSaastaa, 
                        this.transform.position, 
                        this.transform.rotation
                );
                particlesActivated = true;
                paskaSaastaaInstance.GetComponent<Renderer>().material.color = prefabColor;
                paskaSaastaaInstance.GetComponent<ParticleSystem>().maxParticles = 50;
            }
            if (this.condition >= 30 && particlesActivated) {
                if (paskaSaastaaInstance != null) {
                    Destroy(paskaSaastaaInstance);
                }
            }
            if(this.condition <= 0)
            {
                Debug.Log("I AM DED");
                Destroy(this.gameObject);
            }
            if(this.gameObject.tag.Equals("Bush"))
            {
                growBush();
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
        Rigidbody collidingObject = col.rigidbody;
        Debug.Log(collidingObject.gameObject.tag);
        if (collidingObject.gameObject.tag.Equals("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (isValidTool(this, collidingObject))
                {
                    GameObject player = GameObject.Find("Pelaaja");
                    Player playerScript = player.GetComponent<Player>();
                    playerScript.currentProgress = this.condition;

                    repairObject();
                    if (this.gameObject.tag.Equals("Bush") || this.gameObject.tag.Equals("Trunk"))
                    {
                        cutBush();
                    }
                }
            }
        }

    }

    private void repairObject() {
        this.condition += 5;
        //Debug.Log(this.condition);
    }

    private void growBush()
    {

        Vector3 currentscale = this.gameObject.transform.localScale;
        Vector3 newscale = new Vector3(currentscale.x + growRate, currentscale.y + growRate, currentscale.z + growRate);
        //this.gameObject.transform.localScale.Set(0.2f, 0.2f, 0.2f);

        if (currentscale.x < growLimit && currentscale.y < growLimit && currentscale.z < growLimit)
        {
            this.gameObject.transform.localScale = newscale;
        }
    }

    private void cutBush()
    {
        Debug.Log("Cutting the bush");
        GameObject objectToCut;

        if (this.gameObject.tag.Equals("Trunk"))
        {
            objectToCut = this.transform.parent.gameObject;
            Debug.Log("Cutting via trunk");
        } else
        {
            objectToCut = this.gameObject;
            Debug.Log("Cutting via bush");
        }

        Vector3 currentscale = objectToCut.transform.localScale;
        Vector3 newscale = new Vector3(currentscale.x - repairRate, currentscale.y - repairRate, currentscale.z - repairRate);
        //this.gameObject.transform.localScale.Set(0.2f, 0.2f, 0.2f);

        if (currentscale.x > scaleLimit && currentscale.y > scaleLimit && currentscale.z > scaleLimit && !this.gameObject.tag.Equals("Trunk"))
        {
            objectToCut.transform.localScale = newscale;
        }
        //Debug.Log(this.condition);
    }

    private bool isValidTool(Case targetObject, Rigidbody collidingTool)
    {
        return true;
    }

}
