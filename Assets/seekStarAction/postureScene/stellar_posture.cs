using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stellar_posture : MonoBehaviour
{
    public stellar_rotate sr;
    public float stellarAlpha, maxAlpha;
    public float pos, speed, passtime;
    private List<SpriteRenderer> stellarSprite = new List<SpriteRenderer>();
    private int stellarsNum;
    private Color color;
    private float times;
    private bool isStop = false;

    void Start()
    {
        stellarsNum = sr.stellars.Count;
        color = new Color(1, 1, 1, stellarAlpha);
        for (int i = 0; i < stellarsNum; i++)
        {
            stellarSprite.Add(sr.stellars[i].GetComponent<SpriteRenderer>());
        }
    }

    void Update()
    {
        ColorCtrl();
    }

    private void ColorCtrl()
    {
        if (stellarAlpha < 0)
        {
            pos = -pos;
            stellarAlpha = 0;
            isStop = true;
        }
        else if (stellarAlpha > maxAlpha)
        {
            pos = -pos;
            stellarAlpha = maxAlpha;
            isStop = true;
        }
        if (isStop) stopSecond(passtime);
        else stellarAlpha += pos * speed * Time.deltaTime;
        color.a = stellarAlpha;
        for (int i = 0; i < stellarsNum; i++) { stellarSprite[i].color = color; }
        sr.stellars_main.GetComponent<SpriteRenderer>().color = color;
    }

    private void stopSecond(float pt){
        times += Time.deltaTime;
        if (times > pt){
            times = 0;
            isStop = false;
        }
    }
}
