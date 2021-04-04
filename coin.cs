using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //FindObjectOfType<effect>().co_effect();
            Destroy(gameObject);
            FindObjectOfType<Score>().SetScore();
            
        }

    }
}
