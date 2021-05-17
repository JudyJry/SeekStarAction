using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serialSend : MonoBehaviour
{
    public SerialController serialController;
    public seekScene seekScene;
    private string message;
    public bool canPress = true;
    
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sending A");
            seekScene.ledLight(50);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Sending Z");
            seekScene.ledLight(100);
        }

    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
        string[] subs = msg.Split(',');
        if (subs[0] == "b" && canPress){
            if (int.Parse(subs[1]) == seekScene.btnInt[0]){
                seekScene.btnPressed(0);
                seekScene.ledLight(4);
                seekScene.startPlayMovie(0,1);
            }
            if (int.Parse(subs[1]) == seekScene.btnInt[1]){
                seekScene.btnPressed(1);
                seekScene.ledLight(6);
                seekScene.startPlayMovie(1,3);
            }
            if (int.Parse(subs[1]) == seekScene.btnInt[2]){
                seekScene.btnPressed(2);
                seekScene.ledLight(8);
                seekScene.startPlayMovie(2,5);
            }
            if (int.Parse(subs[1]) == seekScene.btnInt[3]){
                seekScene.btnPressed(3);
                seekScene.ledLight(10);
                seekScene.startPlayMovie(3,7);
            }
        }
    }

    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
