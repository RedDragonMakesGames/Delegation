using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public GameObject finalScore;
    public TMPro.TextMeshProUGUI text;
    public float maxTime = 20;

    private float currentTime;
    private float startTime;

    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        currentTime = maxTime;
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = (float)Math.Round(maxTime - (Time.realtimeSinceStartup - startTime), 1);
        if (currentTime >= 0)
            text.text = currentTime.ToString();
        else if (!finished)
        {
            finished = true;
            finalScore.GetComponent<CollectScore>().CollectScores();
            text.text = "Press space to restart";
        }
    }
}
