using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starbring : MonoBehaviour
{
    public float sTime;
    public float sRotate;
    public float sScale;
    public float times;

    void Start()
    {
        sTime = Random.Range(1, 3);
        sRotate = Random.Range(10, 15);
        sScale = Random.Range(0.05f, 0.1f);
    }

    void Update()
    {
        times += Time.deltaTime;
        if (times >= sTime * 2)
        {
            times = 0;
        }
        if (times < sTime)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, sRotate * Time.deltaTime));
            gameObject.transform.localScale += new Vector3(sScale * Time.deltaTime, sScale * Time.deltaTime, 0);
        }
        else if (times > sTime)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, sRotate * Time.deltaTime));
            gameObject.transform.localScale += new Vector3(-sScale * Time.deltaTime, -sScale * Time.deltaTime, 0);
        }
    }
}
