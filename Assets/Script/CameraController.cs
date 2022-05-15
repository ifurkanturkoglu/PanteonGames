using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 camDistance = new Vector3(0f,5.6f,-6.82f);
    
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.TransformPoint(camDistance);
        this.transform.LookAt(player.transform);
    }
}
