using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrailRainbow : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Gradient graident = new Gradient();
        GradientColorKey[] gck = new GradientColorKey[7];
        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0f;
        gak[0].time = 0f;
        gak[1].alpha = 0.7f;
        gak[1].time = 1f;
        gck[0].color = Color.red;
        gck[0].time = 1f / 8f;
        //orange
        gck[1].color = new Color(1f, 0.5f, 0f);
        gck[1].time = 2f / 7f;
        //yellow
        gck[2].color = new Color(1.0f, 1f, 0f);
        gck[2].time = 3f / 7f;
        gck[3].color = Color.green;
        gck[3].time = 4f / 7f;
        gck[4].color = Color.blue;
        gck[4].time = 5f / 7f;
        //Violet
        gck[5].color = new Color(0.5f, 0f, 1f);
        gck[5].time = 6f/ 7f;
        //Purple
        gck[6].color = new Color(0.5f, 0f, 0.5f);
        gck[6].time = 1f;
        graident.SetKeys(gck, gak);
        GetComponent<TrailRenderer>().colorGradient = graident;
    }
}
