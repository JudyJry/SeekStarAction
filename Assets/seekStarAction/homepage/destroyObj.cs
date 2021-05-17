using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObj : MonoBehaviour
{
    public float DeadTime;
    private float times = 0;
    void Start()
    {
        
    }

    void Update()
    {
        times+=Time.deltaTime;
        if (times > DeadTime){
            Destroy(gameObject);
        }
    }
}
