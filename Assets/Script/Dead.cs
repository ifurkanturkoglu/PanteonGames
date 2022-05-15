using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject spawn;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") | other.gameObject.CompareTag("Opponent") ){

            other.gameObject.GetComponent<Transform>().position = spawn.transform.position;
            
        }
    }
}
