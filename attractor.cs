using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{
    // Start is called before the first frame update

    public float coin_speed_toPlayer = 25;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, coin_speed_toPlayer * Time.deltaTime);

        }
    }
}
