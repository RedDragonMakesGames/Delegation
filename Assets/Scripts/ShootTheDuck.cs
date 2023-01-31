using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTheDuck : MonoBehaviour
{
    public float pointsForWin = 15;
    public float points = 0;
    public GameObject score;

    public float left = -10.0f;
    public float right = 10.0f;
    public float duckLeft = -1.0f;
    public float duckRight = 1.0f;
    public float speed = 1.0f;

    private bool goingRight = true;
    public bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    private void FixedUpdate()
    {
        if (!finished)
        {
            if (goingRight)
            {
                transform.position += new Vector3(speed, 0);
                if (transform.position.x > right)
                {
                    goingRight = false;
                }
            }
            else
            {
                transform.position -= new Vector3(speed, 0);
                if (transform.position.x < left)
                {
                    goingRight = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stop()
    {
        finished = true;
        if (transform.position.x < duckRight && transform.position.x > duckLeft)
        {
            points = pointsForWin;
        }
        score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
    }

    public void AI()
    {
        if (!finished)
        {
            if (transform.position.x < duckRight && transform.position.x > duckLeft)
                Stop();
        }
    }
}
