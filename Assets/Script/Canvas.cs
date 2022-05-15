using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    GameObject[] opponents;
    GameObject[] opponentsText;

    GameObject playerObject;
    public Font font;

    public GameObject finish;

    Transform finishPosition;

    float timeToGo;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        opponents = GameObject.FindGameObjectsWithTag("Opponent");
        getOpponentsName();
        opponentsText = GameObject.FindGameObjectsWithTag("opponentText");
        Debug.Log(opponentsText[0]);
        finishPosition = finish.GetComponent<Transform>();
        timeToGo = Time.fixedTime + 1.0f;
        
    }

   
    void FixedUpdate()
    {
        if (Time.fixedTime >= timeToGo) {
         // Do your thang
         timeToGo = Time.fixedTime + 1.0f;
         distanceCalc();
     }

    }
    void getOpponentsName()
    {   
        int a = Screen.height-30;

        GameObject player = new GameObject();
        player.transform.parent = transform;
        player.transform.position = new Vector3(150f,a,0f);
        player.AddComponent<Text>().name = playerObject.name;
        player.GetComponent<Text>().font = font;
        player.GetComponent<Text>().text = playerObject.name;
        player.GetComponent<Text>().color= Color.red;
        player.GetComponent<RectTransform>().sizeDelta = new Vector2(110,20);
        player.GetComponent<Text>().tag = "Player";
        
        foreach (var item in opponents)
        {   
            a -=10;
            GameObject txt = new GameObject();
            txt.transform.parent = transform;
            txt.transform.position = new Vector3(100f,a,0f);
            txt.AddComponent<Text>().name = item.name;
            txt.GetComponent<Text>().font = font;
            txt.GetComponent<Text>().text = item.name;
            txt.GetComponent<Text>().color= Color.red;
            txt.GetComponent<RectTransform>().sizeDelta = new Vector2(110,20);
            txt.GetComponent<Text>().tag = "opponentText";
        }
        
    }
    void distanceCalc(){
        
        float[] distanceArray = new float[opponentsText.Length];
        for (int i = 0; i < opponentsText.Length-1; i++)
        {            
            
            var distance = finishPosition.position.z - opponents[i].transform.position.z;
            
            distanceArray[i] = distance;
           
                
        }
         for(int j = 0; j < distanceArray.Length-1; j++){
            
            if(distanceArray[j] < distanceArray[j+1]){
                var temp = opponentsText[j];
                opponentsText[j] = opponentsText[j+1];
                opponentsText[j+1] = temp;
                Debug.Log(opponentsText[j]);
            } 
        }
        int a = Screen.height-30;
        foreach (var item in opponentsText)
        {
            a -=20;
            item.transform.position = new Vector3(150f,a,0f);
        }
        
    }
    
}
