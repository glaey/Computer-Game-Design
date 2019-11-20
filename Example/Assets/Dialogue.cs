using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialogue : MonoBehaviour
{
  public GameObject text;

  private bool flag;
  // Start is called before the first frame update
  void Start()
  {
    flag = false;


  }

  // Update is called once per frame
  void Update()
  {
    if (flag)
    {
      if (Input.GetKeyDown("j"))
      {
        text.SetActive(true);

      }
    }


  }

  void OnTriggerEnter(Collider other)
  {
    print("collided");
    flag = true;




  }


}
