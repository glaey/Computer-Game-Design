using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactible : MonoBehaviour
{
  Vector3 position;
  public GameObject spriteObj;
  public float height = 1.0f;
  // Start is called before the first frame update
  void Start()
  {
    spriteObj.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
    spriteObj.transform.position = gameObject.transform.position + new Vector3(0f, height, 0f);
    spriteObj.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (spriteObj.activeSelf)
    {

      if (Input.GetKeyDown("j"))
      {
        GameObject.Find("dialogManager").GetComponent<dlgMgr>().DisplayNextSentence();




      }
      if (Input.GetKeyDown("k"))
      {

      }

    }

  }

  void OnTriggerEnter(Collider other)
  {
    print("show");
    spriteObj.SetActive(true);
    GetComponent<dlgTrigger>().TriggerDialogue();


  }

  void OnTriggerExit(Collider other)
  {
    print("hide");
    spriteObj.SetActive(false);
  }
}
