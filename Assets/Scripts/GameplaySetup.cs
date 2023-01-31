using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySetup : MonoBehaviour
{
    public int AIDelay = 30;
    private int count = 0;

    private bool[] delegating;

    delegate void ToDo();
    ToDo todo;

    RandomNumberController random;
    Inflate inflate;
    KeepLevel level;
    ShootTheDuck duck;
    Maths sum;
    Bomb bomb;

    // Start is called before the first frame update
    void Start()
    {
        random = FindObjectOfType<RandomNumberController>();
        inflate = FindObjectOfType<Inflate>();
        level = FindObjectOfType<KeepLevel>();
        duck = FindObjectOfType<ShootTheDuck>();
        sum = FindObjectOfType<Maths>();
        bomb = FindObjectOfType<Bomb>();


        delegating = FindObjectOfType<ButtonManager>().delegating;

        if (delegating[0] == true)
        {
            todo += DoRandom;
            random.pointsForWin = random.pointsForWin / 2;
        }
        if (delegating[1] == true)
        {
            todo += DoInflate;
            inflate.pointsForWin = inflate.pointsForWin / 2;
        }
        if (delegating[2] == true)
        {
            todo += DoLevel;
            level.pointsForWin = level.pointsForWin / 2;
            level.points = level.pointsForWin;
        }
        if (delegating[3] == true)
        {
            todo += DoDuck;
            duck.pointsForWin = duck.pointsForWin / 2;
        }
        if (delegating[4] == true)
        {
            todo += DoMaths;
            sum.pointsForWin = sum.pointsForWin / 2;
        }
        if (delegating[5] == true)
        {
            todo += DoBomb;
            bomb.pointsForWin = bomb.pointsForWin / 2;
            bomb.points = bomb.pointsForWin;
            bomb.UpdateScore();
        }
    }

    private void FixedUpdate()
    {
        count++;
        if (count >= AIDelay)
        {
            count = 0;
            if (todo != null)
                todo();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoRandom()
    {
        random.AI();
    }

    void DoInflate()
    {
        inflate.AI();
    }

    void DoLevel()
    {
        level.AI();
    }

    void DoDuck()
    {
        duck.AI();
    }

    void DoMaths()
    {
        sum.AI();
    }

    void DoBomb()
    {
        bomb.AI();
    }
}
