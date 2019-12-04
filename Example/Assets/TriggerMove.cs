using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMove : MonoBehaviour
{
    public int Req;
    private int Current;
    private bool open;
    private bool moving;
    public float distance;
    public float dur;
    private float startY;
    public bool upwards;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (open)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (distance * Time.deltaTime / dur), transform.position.z);
                if(transform.position.y < startY - distance)
                {
                    moving = false;
                }
            } else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (distance * Time.deltaTime / dur), transform.position.z);
                if (transform.position.y > startY)
                {
                    moving = false;
                }
            }
            
        }
    }

    public void Increment()
    {
        Current++;
        if(Current == Req)
        {
            open = true;
            moving = true;
        }
        print(Current);
    }

    public void Decrement()
    {
        Current--;
        if(open && Current < Req)
        {
            open = false;
            moving = true;
        }
        print(Current);
    }
}
