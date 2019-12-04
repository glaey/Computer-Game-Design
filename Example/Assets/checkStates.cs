using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkStates : MonoBehaviour
{
    public bool isOccupied = false;
    private GameObject exitMgr;
    // Start is called before the first frame update
    void Start()
    {
        exitMgr = GameObject.Find("ExitManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter()
    // {
    //     isOccupied = true;
    //     exitMgr.GetComponent<exitBehavior>().OnChange();


    // }

    void OnTriggerStay()
    {
        isOccupied = true;
        exitMgr.GetComponent<exitBehavior>().OnChange();

    }

    void OnTriggerExit()
    {
        isOccupied = false;
        exitMgr.GetComponent<exitBehavior>().OnChange();

        
    }
}
