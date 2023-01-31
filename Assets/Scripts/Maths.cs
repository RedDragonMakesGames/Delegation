using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Maths : MonoBehaviour
{
    public float pointsForWin = 20;
    public float points = 0;
    public GameObject score;

    private TMPro.TextMeshProUGUI text;

    public int num1Size = 20;
    private int num1;
    public int num2Size = 20;
    private int num2;
    public int goal;
    private int current = 0;

    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        num1 = Random.Range(0, num1Size);
        num2 = Random.Range(num1Size, num1Size + num2Size);
        goal = num2 - num1;
        text.text = num2.ToString() + " - " + num1.ToString() + " = " + current.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        finished = true;
        if (current == goal)
            points = pointsForWin;
        score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
    }

    public void Increase()
    {
        if (finished)
            return;

        current++;
        text.text = num2.ToString() + " - " + num1.ToString() + " = " + current.ToString();
    }

    public void AI()
    {
        if (!finished)
        {
            if (current < goal)
                Increase();
        }
    }
}
