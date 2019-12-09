using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public int purpleGoal;
    public int yellowGoal;
    int purpleMush = 0;
    int yellowMush = 0;
    private bool lvl1;
    private bool lvl2;
    private bool lvl3;
    // Start is called before the first frame update
    GameObject manager;
    void Start()
    {
        manager=GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<SceneState>().levels[1] == true)
        pickUpPenguin();
        if (manager.GetComponent<SceneState>().levels[2]==true)
        pickUpRed();
        if(manager.GetComponent<SceneState>().levels[3]==true)
        pickUpGreen();
        
    }

    public void pickUpPurple()
    {
        Text purpleText;
        purpleMush++;
        purpleText=gameObject.transform.Find("PurpleMushroom").Find("Amount").GetComponent<Text>();
        purpleText.text = purpleMush.ToString();
        if(purpleMush>=purpleGoal)purpleText.text="<color=#1E6C1D>"+purpleText.text+"</color>";
        CheckIfWin();
    }
    public void pickUpYellow()
    {
        Text yellowText;
        yellowMush++;

        yellowText=gameObject.transform.Find("YellowMushroom").Find("Amount").GetComponent<Text>();
        yellowText.text = yellowMush.ToString();
        if(yellowMush>=purpleGoal)yellowText.text="<color=#1E6C1D>"+yellowText.text+"</color>";
        CheckIfWin();
    }
    public void pickUpRed()
    {
        Text redText;

        redText=gameObject.transform.Find("RedCrystal").Find("Amount").GetComponent<Text>();
        redText.text="<color=#1E6C1D>"+1+"</color>";
        lvl1 = true;
        CheckIfWin();
    }
    public void pickUpGreen()
    {
        Text greenText;

        greenText=gameObject.transform.Find("GreenCrystal").Find("Amount").GetComponent<Text>();
        greenText.text="<color=#1E6C1D>"+1+"</color>";
        lvl2 = true;
        CheckIfWin();
    }

    public void pickUpPenguin()
    {
        Text greenText;

        greenText = gameObject.transform.Find("Penguin").Find("Amount").GetComponent<Text>();
        greenText.text = "<color=#1E6C1D>" + 1 + "</color>";
        lvl3 = true;
        CheckIfWin();

    }

    public void CheckIfWin()
    {
        if(lvl1 && lvl2 & lvl3 && (purpleMush >= purpleGoal ) && (yellowMush >= yellowGoal))
        {
            SceneManager.LoadScene("Menu");
        }
    }


}
