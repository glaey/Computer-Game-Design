using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterTrigger : MonoBehaviour
{
    public GameObject triggerDoor;
    TriggerMove triggerMove;
    // Start is called before the first frame update
    void Start()
    {
        triggerMove = triggerDoor.GetComponent<TriggerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Critter" || other.tag == "Baby")
        {
            triggerMove.Increment();
            print("bunny desu");
            other.gameObject.GetComponent<Critter>().Stop();
            other.gameObject.transform.position = transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Critter" || other.tag == "Baby")
        {
            triggerMove.Decrement();
            print("bunny out desu");
        }
    }
}
