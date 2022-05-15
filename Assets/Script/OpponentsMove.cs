using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentsMove : MonoBehaviour
{
    float speed = 2f;
    
    RaycastHit hit;

    Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMove",true);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out RaycastHit hit,2f)){
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) , Color.red);
            

            if(hit.collider.gameObject.tag.Equals("rotatePlatformLeft") | hit.collider.gameObject.tag.Equals("rotatePlatformRight")){
                transform.Translate(transform.forward*speed*Time.deltaTime);
            }
            
            else if(hit.collider.gameObject.transform.position.x > transform.position.x)
            {
                transform.Translate(-transform.right* speed*Time.deltaTime);
            } 
            else if (hit.collider.gameObject.transform.position.x < transform.position.x ){
                transform.Translate(transform.right* speed*Time.deltaTime);
            }
        }
        else{
            transform.Translate(transform.forward*speed * Time.deltaTime,Space.World);
            
        }
    }
}
