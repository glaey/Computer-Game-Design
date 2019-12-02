using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    bool activeCd = false;
    public float SwipeCd = 1f;
    float timesum;
    public GameObject swipe;
    // Start is called before the first frame update
    void Start()
    {
        //swipe = GameObject.Find("Swipe").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeCd)
        {
            if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1)))
            {
                Instantiate(swipe, transform.position, transform.rotation);
                activeCd = true;
            }
        }
        else
        {
            timesum += Time.deltaTime;
            if(timesum > SwipeCd)
            {
                activeCd = false;
                timesum = 0;
            }
        }
    }
}
