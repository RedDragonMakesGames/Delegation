using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflate : MonoBehaviour
{
    public float pointsForWin = 15;
    public float points = 0;
    public GameObject score;

    public float inflateAmount = 0.1f;
    public float targetSize = 10.0f;

    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        finished = true;
    }

    public void Pump()
    {
        if (!finished)
        {
            transform.localScale += transform.localScale * inflateAmount;
            if (transform.localScale.x >= targetSize)
            {
                finished = true;
                points = pointsForWin;
                score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
            }
        }
    }

    public void AI()
    {
        if (!finished)
            Pump();
    }
}
