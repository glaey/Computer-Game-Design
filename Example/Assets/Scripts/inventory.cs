using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public int purpleGoal;
    public int yellowGoal;
    int purpleMush = 0;
    int yellowMush = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickUpPurple()
    {
        Text purpleText;
        purpleMush++;
        purpleText=gameObject.transform.Find("PurpleMushroom").Find("Amount").GetComponent<Text>();
        purpleText.text = purpleMush.ToString();
        if(purpleMush>=purpleGoal)purpleText.text="<color=#1E6C1D>"+purpleText.text+"</color>";
        
    }
    public void pickUpYellow()
    {
        Text yellowText;
        yellowMush++;

        yellowText=gameObject.transform.Find("YellowMushroom").Find("Amount").GetComponent<Text>();
        yellowText.text = yellowMush.ToString();
         if(yellowMush>=purpleGoal)yellowText.text="<color=#1E6C1D>"+yellowText.text+"</color>";

    }
    
}
