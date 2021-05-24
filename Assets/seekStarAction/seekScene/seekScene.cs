using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekScene : MonoBehaviour
{
    public GameObject hpObj, rocket;
    public GameObject Transitions;
    public serialSend serialSend;
    public Animator rocket_anim;
    public List<GameObject> movie;
    public int[] btnInt;
    [HideInInspector]
    public string p = "p";

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            StartCoroutine(playMovie(0, 1));
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            StartCoroutine(playMovie(1, 3));
        }
        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            StartCoroutine(playMovie(2, 5));
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            StartCoroutine(playMovie(3, 7));
        }
    }

    public void btnPressed(int i)
    {
        btnInt[i] = -1;
    }

    public void ledLight(int i)
    {
        if (serialSend.gameObject.activeSelf)
        {
            serialSend.serialController.SendSerialMessage("L," + i);
        }
    }

    public void startPlayMovie(int i, int j)
    {
        StartCoroutine(playMovie(i, j));
    }

    public void canPressButton(bool canPress)
    {
        serialSend.canPress = canPress;
    }

    private IEnumerator playMovie(int i, int j)
    {
        canPressButton(false);
        rocket_anim.SetInteger(p, j);
        float WFS = 5f;
        if (i > 1) { WFS = 5.5f; }
        yield return new WaitForSeconds(WFS);
        Instantiate(Transitions);
        yield return new WaitForSeconds(1f);
        rocket_anim.SetBool("a", true);
        Instantiate(movie[i]);
        rocket_anim.SetInteger(p, j + 1);
        Debug.Log("play movie P" + i);
        hpObj.SetActive(false);
    }
}
