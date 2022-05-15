using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWall : MonoBehaviour
{
    
    
    public GameObject brush;

    public float brushSize = 0.1f;
    

    void Update()
    {
        if(Input.GetMouseButton(0)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                Debug.Log(hit.collider.gameObject);
                if(hit.collider.gameObject.CompareTag("paintWall")){
                    var paint = Instantiate(brush, hit.point + new Vector3(0f,0f,-0.01f),Quaternion.Euler(-90f,0f,0f),transform);
                    paint.transform.localScale = new Vector3(0.2f,0.2f,0.2f) * brushSize;
                }
                
            }
        }
    }
    
}
