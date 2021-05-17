using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homepage : MonoBehaviour
{
    public KinectManager kinectManager;
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
        if ((kinectManager.IsUserDetected() || Input.GetKeyUp(KeyCode.Space)) && !start)
        {
            StartCoroutine(playerReady());
            start = true;
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

    private IEnumerator playerReady()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(startTransitions);
        startM = true;
    }
}
