using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObj : MonoBehaviour
{
    public float DeadTime;
    public GameObject InstantiateObj;
    private float times = 0;
    void Start()
    {
        
    }

    void Update()
    {
        times+=Time.deltaTime;
        if (times > DeadTime){
            if (InstantiateObj){
                Instantiate(InstantiateObj);
            }
            Destroy(gameObject);
        }
    }
}
