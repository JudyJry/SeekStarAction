using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stellar_rotate : MonoBehaviour
{
    public postureScene ps;
    public Transform center;
    public List<GameObject> stellars = new List<GameObject>();
    public bool haveMain;
    public int main_index;
    [HideInInspector]
    public GameObject stellars_main;
    public float distance = 4;
    public float rotateSpeed = 1;
    public float n_scale_float;
    private int stellarsNum;
    private float angle;
    private Vector3 main_scale = new Vector3(2.5f, 2.5f, 2.5f);
    private Vector3 n_scale;
    private bool SelectMain_bool = false, SelectN_bool = false;
    private float times = 0;

    void Start()
    {
        n_scale = Vector3.one * n_scale_float;
        if (haveMain)
        {
            stellars_main = stellars[main_index];
            stellars.RemoveAt(main_index);
            stellars_main.transform.localScale = main_scale;
        }
        stellarsNum = stellars.Count;
        angle = 360 / stellarsNum;
        for (int i = 0; i < stellarsNum; i++)
        {
            stellars[i].transform.localScale = n_scale;
        }
    }

    void Update()
    {
        SetDistance();
        ControlRatate();
        if (haveMain)
        {
            if (Input.GetKeyUp(KeyCode.Keypad1))
            {
                SelectMain_bool = true;
            }
            else if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                SelectN_bool = true;
            }
        }
        if (SelectMain_bool) SelectMain();
        if (SelectN_bool)
        {
            mainChange(main_index,2);
            SelectN();
        }
    }

    private void ControlRatate()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        for (int i = 0; i < stellarsNum; i++)
        {
            stellars[i].transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
        if (haveMain)
        {
            stellars_main.transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }
    private void SetDistance()
    {
        for (int i = 0; i < stellarsNum; i++)
        {
            stellars[i].transform.localPosition = Quaternion.Euler(0, 0, angle * i) * Vector3.up * distance;
        }
        if (haveMain)
        {
            stellars_main.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    private void mainChange(int old_index, int new_index)
    {
        stellars.Insert(old_index,stellars_main);
        main_index = new_index;
        stellars_main = stellars[main_index];
        stellars.RemoveAt(main_index);
        stellars_main.transform.localScale = main_scale;
        for (int i = 0; i < stellarsNum; i++)
        {
            stellars[i].transform.localScale = n_scale;
        }
    }
    private void SelectMain()
    {
        times += Time.deltaTime;
        distance += 3 * Time.deltaTime;
        rotateSpeed += 3 * Time.deltaTime;
        stellars_main.transform.localScale += Vector3.one * Time.deltaTime;
        if (times > 2)
        {
            times = 0;
            SelectMain_bool = false;
            ps.start = true;
        }
    }
    private void SelectN()
    {
        times += Time.deltaTime;
        distance += 3 * Time.deltaTime;
        rotateSpeed += 3 * Time.deltaTime;
        stellars_main.transform.localScale += Vector3.one * Time.deltaTime;
        if (times > 2)
        {
            times = 0;
            SelectN_bool = false;
            ps.start = true;
        }
    }
}
