using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    float speed = 0.3f;

    float force = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        if(gameObject.CompareTag("horizontalObstacleR")){
            
            animator.SetBool("right",true);
        } 
        if(gameObject.CompareTag("horizontalObstacleL")){
            
            animator.SetBool("right",false);
        } 
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("rotatePlatformLeft")) transform.Rotate(new Vector3(0f,0f,100f)*Time.deltaTime);
        if(gameObject.CompareTag("rotatePlatformRight")) transform.Rotate(new Vector3(0f,0f,-100f)*Time.deltaTime);
        if(gameObject.CompareTag("horizontalObstacleR")) transform.Rotate(new Vector3(0f,-100f,0f)*Time.deltaTime);
        if(gameObject.CompareTag("horizontalObstacleL")) transform.Rotate(new Vector3(0f,-100f,0f)*Time.deltaTime);
        if(gameObject.CompareTag("rotator")) transform.Rotate(new Vector3(0f,-100f,0f)*Time.deltaTime);
    }
    void OnTriggerStay(Collider other)
    {
        if(gameObject.CompareTag("rotatePlatformLeft"))other.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.right*speed,ForceMode.Impulse);
        if(gameObject.CompareTag("rotatePlatformRight"))other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right*speed,ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("horizontalObstacleR")){
           
            other.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.right*force,ForceMode.Impulse);
        } 
        if(gameObject.CompareTag("horizontalObstacleL")){
            
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right*force,ForceMode.Impulse);
        }
        if(gameObject.CompareTag("stick") | gameObject.CompareTag("rotator")){
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y,other.gameObject.transform.position.z),ForceMode.Impulse);
        }
        if(gameObject.CompareTag("donat")){
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.transform.forward*force,ForceMode.Impulse);
        }
         
    }
}
