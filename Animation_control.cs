using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Camera camera;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dance()
    {
        animator.SetBool("iscomplete", true);
    }
    public void Jump()
    {
        animator.SetBool("isjump", true);
        Invoke("NotJump", 1);
    }
    public void NotJump()
    {
        animator.SetBool("isjump", false);
        
    }
    public void Death()
    {
        animator.SetBool("isdead", true);
        
    }
    
    
    /*public void isbigg()
    {
        Debug.Log("in bifgggg...");
        animator.SetBool("isbig", true);
        Invoke("pausebig", 1f);
        
    }
    
    public void pausebig()
    {
        Debug.Log("in samlllll...");
        animator.SetBool("isbig", false);
    }
    */
}
