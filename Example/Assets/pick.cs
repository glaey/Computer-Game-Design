using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject inventory;
    public string type;
    private bool activated;
  void Start()
  {
    inventory = GameObject.Find("Inventory");
  }

  // Update is called once per frame
  void Update()
  {
        if (activated)
        {
            if (type == "Purple Mushroom")
            {
                inventory.GetComponent<inventory>().pickUpPurple();
            }
            else if (type == "Yellow Mushroom")
            {
                inventory.GetComponent<inventory>().pickUpYellow();
            }
            Destroy(gameObject);
            Debug.Log("in");
        }
  }

    /*
  void OnTriggerEnter(Collider other)
  {
    print("Trigger");
    if (other.gameObject.tag == "Bear")
    {
      if (GetComponent<item>().type == "Purple Mushroom")
      {
        inventory.GetComponent<inventory>().pickUpPurple();
      }
      Destroy(gameObject);
    }
  } */

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Player" && (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F)))
        {
            activated = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.tag == "Player" && (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F)))
        {
            activated = true;
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {

    //     if(collision.gameObject.tag == "Pickup")
    //     {
    //         if (collision.gameObject.GetComponent<item>().type == "Purple Mushroom"){
    //             inventory.GetComponent<inventory>().pickUpPurple();
    //         }
    //         Destroy(collision.gameObject);
    //   print("something");
    // }
    // }
}
