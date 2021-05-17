using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seekEnd : MonoBehaviour
{
    public GameObject trans;
    public string scene;
    private bool isEnd = false;
    private float times;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd){
            times += Time.deltaTime;
            if (times > 1) {
                SceneManager.LoadScene(scene);
            }
        }
    }

    public void end(){
        isEnd = true;
        Instantiate(trans);
    }
}
