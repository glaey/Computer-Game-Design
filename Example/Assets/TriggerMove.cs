using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMove : MonoBehaviour
{
    public bool movebased;
    public int Req;
    private int Current;
    private bool open;
    private bool moving;
    public float distance;
    public float dur;
    private float startY;
    public bool upwards;
    private float percentage = 1f;
    Material m;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m = gameObject.GetComponent<MeshRenderer>().material;
        startY = transform.position.y;
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (movebased)
            {
                MoveDoor();
            }
            else
            {
                MagicDoor();
            }
        }
    }

    void MoveDoor()
    {
        if (open)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (distance * Time.deltaTime / dur), transform.position.z);
            if (transform.position.y < startY - distance && upwards)
            {
                print("first con");
                moving = false;
            }
            else if (transform.position.y > startY - distance && !upwards)
            {
                print("2 con");
                moving = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (distance * Time.deltaTime / dur), transform.position.z);
            if (transform.position.y > startY && upwards)
            {
                moving = false;
            }
            else if (transform.position.y < startY && !upwards)
            {
                moving = false;
            }
        }
    }

    void MagicDoor()
    {
        
        if (open)
        {
            print(percentage + "% open");
            percentage -= (Time.deltaTime / dur);
            if(percentage < 0)
            {
                moving = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            m.SetFloat("_InvFade", percentage);
        }
        else
        {
            print(percentage + "% open");
            percentage += (Time.deltaTime / dur);
            if(percentage > 1)
            {
                moving = false;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            m.SetFloat("_InvFade", percentage);
        }
    }

    public void Increment()
    {
        Current++;
        if(Current == Req)
        {
            open = true;
            moving = true;

            if (movebased)
            {
                audioSource.Play();
            }
        }
    }

    public void Decrement()
    {
        Current--;
        if(open && Current < Req)
        {
            open = false;
            moving = true;

            if (movebased)
            {
                audioSource.Play();
            }
        }
    }
}
