using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_effect : MonoBehaviour
{
    // Start is called before the first frame 
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Effect()
    {
        Debug.Log("Ground effect going....");
        GetComponent<ParticleSystem>().Play();



    }
    public void Pausee()
    {
        Debug.Log("Stoped...");
        GetComponent<ParticleSystem>().Stop();
    }
}
