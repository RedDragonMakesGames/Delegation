using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNumberController : MonoBehaviour
{
    public float pointsForWin = 20;
    public float points = 0;
    public GameObject score;

    public int maxNumber = 100;
    public int speed = 10;

    private bool running = true;
    private TMPro.TextMeshProUGUI text;
    private int targetNumber;
    private int currentNumber;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        targetNumber = Random.Range(0, maxNumber);
        running = true;
    }

    private void FixedUpdate()
    {
        count++;
        if (count >= speed)
        {
            count = 0;
            if (running)
            {
                currentNumber = Random.Range(0, maxNumber);
                text.text = currentNumber.ToString() + "(" + targetNumber.ToString() + ")";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stop()
    {
        running = false;
        if (currentNumber == targetNumber)
        {
            points = pointsForWin;
        }
        score.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
    }

    public void AI()
    {
        if (currentNumber == targetNumber)
            Stop();
    }
}
