using System.Collections;

using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public Camera camera;
    float player_x_position;
    float player_y_position;
    float player_z_position;


    void OnTriggerEnter(Collider other)
    {
        thePlayer.SetActive(false);
        Invoke("Telepathy", 2);
          
    }
 
    public void Telepathy()
    {
        Debug.Log("yyyyyyyyyyyyy");
        thePlayer.SetActive(true);
        thePlayer.transform.position = teleportTarget.transform.position;
        camera.transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y + 11, thePlayer.transform.position.z - 10);
        
    }
    

}
