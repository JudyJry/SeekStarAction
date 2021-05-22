using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stellarTrigger : MonoBehaviour
{
    public GameObject InstantiateObj;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        Instantiate(InstantiateObj);
        Destroy(gameObject);
    }
}
