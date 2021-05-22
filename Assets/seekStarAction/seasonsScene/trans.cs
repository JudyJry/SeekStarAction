using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans : MonoBehaviour
{
    public GameObject startTransitions;
    public float time;
    void Start()
    {
        StartCoroutine(play());
    }

    void Update()
    {
        
    }

    private IEnumerator play()
    {
        yield return new WaitForSeconds(time);
        Instantiate(startTransitions);
    }
}
