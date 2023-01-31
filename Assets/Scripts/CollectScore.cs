using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    public GameObject bomb;
    public GameObject maths;
    public GameObject random;
    public GameObject duck;
    public GameObject level;
    public GameObject inflate;
    public GameObject input;

    private float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectScores()
    {
        bomb.GetComponent<Bomb>().End();
        score += bomb.GetComponent<Bomb>().points;
        maths.GetComponent<Maths>().End();
        score += maths.GetComponent<Maths>().points;
        random.GetComponent<RandomNumberController>().Stop();
        score += random.GetComponent<RandomNumberController>().points;
        duck.GetComponent<ShootTheDuck>().Stop();
        score += duck.GetComponent<ShootTheDuck>().points;
        level.GetComponent<KeepLevel>().End();
        score += level.GetComponent<KeepLevel>().points;
        inflate.GetComponent<Inflate>().End();
        score += inflate.GetComponent<Inflate>().points;

        text.text = "Final score: " + score.ToString();

        input.GetComponent<InputController>().End();
    }
}
