using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLevel : MonoBehaviour
{
    public float pointsForWin = 20;
    public float pointsDrainAmount = 0.1f;
    public float points = 0;
    public float pointDrainSpeed = 20;
    public GameObject score;

    public float lowerBound = 2.0f;
    public float upperBound = 5.0f;
    public float drainAmount = 0.01f;
    public float fillAmount = 0.5f;

    private bool finished = false;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        points = pointsForWin;
    }

    private void FixedUpdate()
    {
        if (!finished)
        {
            //Drain water
            if (transform.localScale.y > 0.1)
            {
                transform.localScale -= new Vector3(0, drainAmount);
                transform.position -= new Vector3(0, drainAmount / 2);
            }

            //Calculate points
            count++;
            if (count > pointDrainSpeed)
            {
                count = 0;
                if (transform.localScale.y < lowerBound || transform.localScale.y >= upperBound)
                {
                    if (points - pointsDrainAmount >= 0)
                    {
                        points -= pointsDrainAmount;
                        points = (float)Math.Round(points, 2);
                    }
                }
            }
        }
        score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void End()
    {
        finished = true;
    }

    public void Fill()
    {
        if (finished)
            return;

        //Fill water
        if (transform.localScale.y < 10)
        {
            transform.localScale += new Vector3(0, fillAmount);
            transform.position += new Vector3(0, fillAmount / 2);
        }
    }

    public void AI()
    {
        if (!finished)
        {
            if (transform.localScale.y < (lowerBound + upperBound) / 2)
            {
                Fill();
            }
        }
    }
}
