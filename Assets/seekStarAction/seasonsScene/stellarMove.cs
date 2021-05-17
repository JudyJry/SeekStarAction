using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stellarMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Mathf.Lerp(-9, 9, Mathf.InverseLerp(0, 1920, Input.mousePosition.x));
        float mouseY = Mathf.Lerp(-5, 5, Mathf.InverseLerp(0, 1080, Input.mousePosition.y));
        transform.position = new Vector2(mouseX,mouseY);
    }
}
