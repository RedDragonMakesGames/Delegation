using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float pointsForWin = 20;
    public float points = 0;
    public GameObject score;

    public Material ok;
    public Material warn;
    public Material explode;

    public int warningTime = 100;
    public int warningChance = 20;

    private bool exploaded = false;
    private bool warning = false;
    private int countdown = 0;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        points = pointsForWin;
        score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
    }

    private void FixedUpdate()
    {
        if (finished)
            return;

        if (!exploaded)
        {
            if (!warning)
            {
                if (Random.Range(0, warningChance) == 0)
                {
                    warning = true;
                    GetComponent<MeshRenderer>().material = warn;
                    countdown = 0;
                }
            }
            else
            {
                countdown++;
                if (countdown > warningTime) 
                {
                    exploaded = true;
                    GetComponent<MeshRenderer>().material = explode;
                    points = 0;
                    score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
                }
            }
        }
    }

    public void End()
    {
        finished = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TouchBomb()
    {
        if (finished)
            return;

        if (exploaded)
            return; 

        if (warning)
        {
            warning = false;
            GetComponent<MeshRenderer>().material = ok;
        }
        else
        {
            exploaded = true;
            GetComponent<MeshRenderer>().material = explode;
            points = 0;
            score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
        }
    }

    public void UpdateScore()
    {
        score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
    }

    public void AI()
    {
        if (!finished)
        {
            if (warning)
                TouchBomb();
        }
    }
}
