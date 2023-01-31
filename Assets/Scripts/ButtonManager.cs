using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] textFields;
    public bool[] delegating;

    // Start is called before the first frame update
    void Start()
    {
        ButtonManager[] buttonManagers = FindObjectsOfType<ButtonManager>();
        foreach (var buttonManager in buttonManagers)
        {
            if (buttonManager.gameObject != this.gameObject)
            {
                Destroy(buttonManager.gameObject);
            }
        }
        delegating = new bool[textFields.Length];
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleClick(int task)
    {
        if (delegating[task])
        {
            delegating[task] = false;
            SetTextOff(task);
        }
        else
        {
            delegating[task] = true;
            SetTextOn(task);
        }
    }

    public void Go()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void SetTextOn(int task)
    {
        switch (task)
        {
            case 0:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Number Stop (Q): Delegating";
                break;

            case 1:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Inflate (W): Delegating";
                break;

            case 2:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Keep Level (E): Delegating";
                break;

            case 3:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Line Up (R): Delegating";
                break;

            case 4:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Maths (T): Delegating";
                break;

            case 5:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Bomb (Y): Delegating";
                break;

            default:
                Debug.LogError("Invalid task ID");
                break;
        }
    }

    private void SetTextOff(int task)
    {
        switch (task)
        {
            case 0:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Number Stop (Q): Not Delegating";
                break;

            case 1:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Inflate (W): Not Delegating";
                break;

            case 2:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Keep Level (E): Not Delegating";
                break;

            case 3:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Line Up (R): Not Delegating";
                break;

            case 4:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Maths (T): Not Delegating";
                break;

            case 5:
                textFields[task].GetComponent<TextMeshProUGUI>().text = "Bomb (Y): Not Delegating";
                break;

            default:
                Debug.LogError("Invalid task ID");
                break;
        }
    }
}
