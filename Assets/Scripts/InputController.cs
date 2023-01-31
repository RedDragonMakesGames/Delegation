using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public GameObject randomNumber;
    public GameObject inflate;
    public GameObject keepLevel;
    public GameObject shootTheDuck;
    public GameObject maths;
    public GameObject bomb;

    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            randomNumber.GetComponent<RandomNumberController>().Stop();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inflate.GetComponent<Inflate>().Pump();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            keepLevel.GetComponent<KeepLevel>().Fill();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            shootTheDuck.GetComponent<ShootTheDuck>().Stop();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            maths.GetComponent<Maths>().Increase();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            bomb.GetComponent<Bomb>().TouchBomb();
        }
    }

    public void End()
    {
        finished = true;
    }
}
