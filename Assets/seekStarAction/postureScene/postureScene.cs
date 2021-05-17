using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postureScene : MonoBehaviour
{
    public GameObject homepageObj;
    public GameObject startTransitions;
    public GameObject startMovie;
    public bool start = false;
    private bool startM = false;
    private float times = 0;
    
    void Start()
    {
        
    }

   void Update()
    {
        if (start)
        {
            Instantiate(startTransitions);
            start = false;
            startM = true;
        }
        if (startM)
        {
            times += Time.deltaTime;
            if (times > 1)
            {
                startMovie.SetActive(true);
                homepageObj.SetActive(false);
            }
            else if (times > 2)
            {
                times = 0;
                startM = false;
            }
        }
    }
}
