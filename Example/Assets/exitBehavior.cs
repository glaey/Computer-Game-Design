using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitBehavior : MonoBehaviour
{


    private bool isOccupied1, isOccupied2, isOccupied3, isOccupied4;

    public GameObject exit;

    private GameObject t1, t2, t3, t4;




    // Start is called before the first frame update
    void Start()
    {
        exit.SetActive(false);

        t1 = GameObject.Find("trigger1");
        t2 = GameObject.Find("trigger2");
        t3 = GameObject.Find("trigger3");
        t4 = GameObject.Find("trigger4");

    }

    // Update is called once per frame
    void Update()
    {



        
    }

    public void OnChange()
    {
        isOccupied1 = t1.GetComponent<checkStates>().isOccupied;
        isOccupied2 = t2.GetComponent<checkStates>().isOccupied;
        isOccupied3 = t3.GetComponent<checkStates>().isOccupied;
        isOccupied4 = t4.GetComponent<checkStates>().isOccupied;



        if(isOccupied1 && isOccupied2 && isOccupied3 && isOccupied4)
        {
            exit.SetActive(true);

        }else{
            exit.SetActive(false);
        }

    }
}
