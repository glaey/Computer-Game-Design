using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
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
        if (other.gameObject.tag == "Stag" && other.gameObject.GetComponent<Deer>().isCharging)
        {
            other.gameObject.GetComponent<Deer>().EndCharge(0.5f);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stag" && other.gameObject.GetComponent<Deer>().isCharging)
        {
            other.gameObject.GetComponent<Deer>().EndCharge(0.5f);
            Destroy(gameObject);
        }
    }
}
