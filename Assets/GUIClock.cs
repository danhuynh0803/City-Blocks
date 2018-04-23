using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GUIClock : MonoBehaviour
{

    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    private bool isStrongSignal;
    private bool isBar2Enable;
    private float time;
    private void Start()
    {
        isStrongSignal = true;
        isBar2Enable = true;
    }

    void Update()
    {
        GetComponent<Text>().text = DateTime.Now.ToString();
        time += Time.deltaTime;
        if(time > 0.5f)
        {
            if (isStrongSignal)
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.3f)
                {
                    bar3.GetComponent<Image>().enabled = false;
                    isStrongSignal = false;
                }
            }
            else
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.4f)
                {
                    bar2.GetComponent<Image>().enabled = false;
                    isBar2Enable = false;
                }
                else
                {
                    if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
                    {
                        bar2.GetComponent<Image>().enabled = true;
                        isBar2Enable = true;
                    }
                }
                if(isBar2Enable)
                {
                    if (UnityEngine.Random.Range(0f, 1f) < 0.3f)
                    {
                        bar3.GetComponent<Image>().enabled = true;
                        isStrongSignal = true;
                    }
                }
            }
            time = 0;
        }
    }
}
