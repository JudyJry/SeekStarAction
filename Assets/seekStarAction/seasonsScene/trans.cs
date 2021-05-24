using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trans : MonoBehaviour
{
    public GameObject startTransitions;
    public string scene;
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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
