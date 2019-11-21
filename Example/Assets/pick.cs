using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject inventory;
  void Start()
  {
    inventory = GameObject.Find("Inventory");
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter(Collider other)
  {
    print("Trigger");
    if (other.gameObject.tag == "Player")
    {
      if (GetComponent<item>().type == "Purple Mushroom")
      {
        inventory.GetComponent<inventory>().pickUpPurple();
      }
      Destroy(gameObject);
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
