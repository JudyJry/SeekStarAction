using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class transition : MonoBehaviour
{
    public GameObject trans;
    public VideoPlayer movie;
    public string scene;
    private bool transed = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movie.time >= movie.clip.length-1 && !transed) {
            Instantiate(trans);
            transed = true;
        }
        if (!movie.isPlaying && transed){
            Debug.Log("movie play end.");
            SceneManager.LoadScene(scene);
        }
    }
}
