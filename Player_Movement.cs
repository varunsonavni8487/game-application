
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    //public float speed_of_player
    // Start is called before the first frame update
    public Camera camera;
    public AudioSource audio;
    public AudioClip clip;
    public AudioClip death;
    
    
    //public GameObject particle;
    bool isground = true;
    bool size_large = true;
    public float player_forward_speed = 0.35f;
    public float camera_forward_speed = 0.35f;
    public float player_left_speed = 0.15f;
    public float camera_left_speed = 0.15f;
    public float player_right_speed = 0.15f;
    public float camera_right_speed = 0.15f;
    public float jump_value_y = 6.5f;
    public float increase_size_x = 1.5f;
    public float increase_size_y = 1.5f;
    public float increase_size_z = 1.5f;
    public float decrease_size_x = 1.5f;
    public float decrease_size_y = 1.5f;
    public float decrease_size_z = 1.5f;
    public float restartTime_whenLevelComplete = 5f;
    public float jumph = 0.2f;
    public float jump_force;
    private Vector3 jump;
    private Rigidbody rigg;
    
    Vector3 minScale;
    public Vector3 maxScale;
    public bool repeat;
    public float speed = 2f;
    public float duration = 5;

    public Text text_inbetween;
    public string[] text = { "Adorable...", "Keep Going...", "Keep it Up..." };
    int temp = 0;

    float timer = 0;
    public int xbuttondistance = 100;
    bool count = false;

    public Text ultstatus;
    void Start()
    {
        jump = new Vector3(0f, jumph, 0f);
        rigg = GetComponent<Rigidbody>();
        minScale = transform.localScale;
        ultstatus.text = "Ultimate Ability (Press X) : Active..";
       
   
    }
    void Update()
    {
        transform.position += new Vector3(0, 0, player_forward_speed);
        camera.transform.position += new Vector3(0, 0, camera_forward_speed);
        if (Input.GetKey("a") || Input.GetKey("left") )
        {
            transform.position += new Vector3(-player_left_speed, 0, 0);
            //transform.localEulerAngles += new Vector3(0, -0.2f, 0);
            camera.transform.position+= new Vector3(-camera_left_speed,0,0);
            
          
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.position += new Vector3(player_right_speed, 0, 0);
            //transform.localEulerAngles += new Vector3(0, 0.2f, 0);
            camera.transform.position+= new Vector3(camera_right_speed,0,0);
        }
        
        if (Input.GetKeyDown(KeyCode.P) && size_large==true)
        {
            //transform.localScale += new Vector3(increase_size_x,increase_size_y,increase_size_z);
            //xxx();
            //FindObjectOfType<Shrink>().big_activate();
            FindObjectOfType<Shrink>().StartCoroutine("call_big");
            Debug.Log("P pressed..");
            size_large = false;
        }
        else if(Input.GetKeyDown(KeyCode.P) && size_large == false)
        {
            //transform.localScale -= new Vector3(decrease_size_x,decrease_size_y,decrease_size_z);
            FindObjectOfType<Shrink>().StartCoroutine("call_small");
            size_large = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isground)                  
        {
            //transform.position += new Vector3(0,jump_value_y, 0);
            //rigg.AddForce(jump * jump_force, ForceMode.Impulse);
            FindObjectOfType<Animation_control>().Jump();
            isground = false;
            //FindObjectOfType<Animation_control>().NotJump();
        }
        if(Input.GetKey(KeyCode.X))
        {

            if(timer < xbuttondistance)
            {
                GetComponent<AudioSource>().Play();
                count = true;
                transform.position += new Vector3(0, 0, 1f);
                camera.transform.position += new Vector3(0, 0, 1f);
                timer++;
            }    
        }
       
        else 
        {
            
            if (count==true)
            {
                
                timer = xbuttondistance;
                ultstatus.text = "Ultimate Ability : Disabled..";
            }
        }
        

    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag == "obstacle")
        {
           
            FindObjectOfType<Animation_control>().Death();
            audio.PlayOneShot(death);
            enabled = false;
            Invoke("Restart",3.0f); //S
        }
        if(collision.collider.tag == "finish_line")
        {

            audio.PlayOneShot(clip);
            enabled = false;
            FindObjectOfType<Animation_control>().Dance();
            FindObjectOfType<Celebration>().effect();
            Invoke("Restart", restartTime_whenLevelComplete);
        }
        if (collision.collider.tag == "ground")
        {
            FindObjectOfType<Coin_effect>().Effect();
        }
        if (collision.collider.tag == "text_trigger" )
        {
            text_inbetween.text = text[temp];
            temp++;
            Invoke("rename", 1.5f);
        }

        if (collision.collider.tag == "ground" )
        {
            isground = true;

        }
        else
        {
            isground = false;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        FindObjectOfType<Coin_effect>().Pausee();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void rename()
    {
        text_inbetween.text = " ";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "text_trigger")
        {
            text_inbetween.text = text[temp];
            temp++;
            Invoke("rename", 1.5f);
        }
    }
    /*void OnTriggerEnter(Collider other)
   {
       Debug.Log(other.tag);
       if (other.tag == "second_jump")
       {
           FindObjectOfType<Coin_effect>().pause();
           //camera.transform.position += new Vector3(0, 12, 0);
           transform.position += new Vector3(0, jump_value_y, 0);
       }
   }*/
}
