using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class movieEnd : MonoBehaviour
{
    public seekScene ss;
    public VideoPlayer vp;
    public bool end;
    void Start()
    {
        ss = GameObject.Find("Main Camera").GetComponent<seekScene>();
        vp = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if(vp.time >= vp.clip.length - 1){
            ss.hpObj.SetActive(true);
            ss.rocket_anim.SetBool("a",false);
            vp.targetCameraAlpha -= 1 * Time.deltaTime;
            ss.canPressButton(true);
            ss.ledLight(1);
        }
        if (end) {
            ss.rocket_anim.SetInteger("p",9);
        }
    }
}
