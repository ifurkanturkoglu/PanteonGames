using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    
    

    Animator animator;
    public float speed = 3f; 

    public float rotationSpeed = 500f;

    public GameObject player;

    public float jump = 100f;

    
    bool isGrounded = false;
    void Start()
    {
        animator = player.GetComponent<Animator>();
        
    }
    void Update()
    {
        


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x,0f,z);
        move.Normalize();
        
        transform.Translate(move*speed*Time.deltaTime,Space.World);
        
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Debug.Log("jump");
            player.GetComponent<Rigidbody>().AddForce(transform.up*jump);
            isGrounded = false;
        }
       

        if(Input.GetButton("Vertical") | Input.GetButton("Horizontal") ){
            animator.SetBool("isMove",true);
        }
        else{
            animator.SetBool("isMove",false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("finish")){
            Debug.Log("finish");
            GetComponent<CharacterMove>().enabled = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log(isGrounded);
        isGrounded = true;
    }
}
