using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    public GameObject newPush;

    // Start is called before the first frame update
    void Start()
    {
            newPush = GameObject.Find("NewPush");
            newPush.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stag" && other.gameObject.GetComponent<move2>().isCharging)
        {
            other.gameObject.GetComponent<move2>().EndCharge(0.5f);
            Destroy(gameObject);
            newPush.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stag" && other.gameObject.GetComponent<move2>().isCharging)
        {
            other.gameObject.GetComponent<move2>().EndCharge(0.5f);
            Destroy(gameObject);
            newPush.SetActive(true);

        }
    }
}
