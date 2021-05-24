using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketEvent : MonoBehaviour
{
    public List<GameObject> rocketAudio;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playAudio(int i){
        Debug.Log("PLAYAUDIO"+i);
        Instantiate(rocketAudio[i]);
    }
}
