using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebration : MonoBehaviour
{
    //public GameObject celebration;
    public GameObject player;
  
    public void effect()
    {
        GetComponent<ParticleSystem>().Play();
    }
}
