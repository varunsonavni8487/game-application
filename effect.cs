using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void co_effect()
    {
        GetComponent<ParticleSystem>().Play();
        //Invoke("Restart", 0.01f);
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "finish_line" || collision.collider.tag == "obstacle") ;
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
  
}
