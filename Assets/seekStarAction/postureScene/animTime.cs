using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animTime : MonoBehaviour
{
    public Animation anim;
    public AnimationClip animName;
    public float times;

    void Start()
    {
        anim[animName.name].time = times;
    }

    void Update()
    {
    }
}
