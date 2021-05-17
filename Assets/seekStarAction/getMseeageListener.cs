using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMseeageListener : MonoBehaviour
{
    public SerialController serialController;

    void Start()
    {
        serialController.messageListener = GameObject.FindGameObjectWithTag("MessageListener");
    }

    void Update()
    {
        
    }
}
