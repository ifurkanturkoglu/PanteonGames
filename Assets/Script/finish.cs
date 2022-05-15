using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject player;
    
    public GameObject paint;
    
    public Camera cam;
   

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("finish");
        
        
        if(other.gameObject.CompareTag("Opponent")){
            other.gameObject.GetComponent<OpponentsMove>().enabled = false;
        }
        else{
            player.GetComponent<CharacterMove>().enabled = false;
            cam.GetComponent<Transform>().position =  player.GetComponent<CharacterMove>().transform.position + Vector3.up;
            cam.GetComponent<Transform>().rotation = Quaternion.Euler(4.251f,2f,-1.1f);
            paint.GetComponent<PaintWall>().enabled = true;
        }
    }
}
