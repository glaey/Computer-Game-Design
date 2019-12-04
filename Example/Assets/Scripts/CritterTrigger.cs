using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterTrigger : MonoBehaviour
{
    public GameObject[] triggerDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Critter" || other.tag == "Baby")
        {
            for(int i = 0; i < triggerDoor.Length; i++)
            {
                triggerDoor[i].GetComponent<TriggerMove>().Increment();
                print("bunny desu");
                //other.gameObject.GetComponent<Critter>().Stop();
                other.gameObject.transform.position = transform.position;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Critter" || other.tag == "Baby")
        {
            for (int i = 0; i < triggerDoor.Length; i++)
            {
                triggerDoor[i].GetComponent<TriggerMove>().Decrement();
            }
        }
    }
}
