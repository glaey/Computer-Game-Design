using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    int purpleMush = 0;
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
        purpleMush++;
        gameObject.transform.Find("PurpleMushroom").Find("Amount").GetComponent<Text>().text = purpleMush.ToString();
    }
    
}
