using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class movieCtrl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.targetCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)){
            videoPlayer.playbackSpeed = 5;
        }
    }
}
