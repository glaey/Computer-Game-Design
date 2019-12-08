using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactible : MonoBehaviour
{
    Vector3 position;
    public GameObject spriteObj;
    public float height = 2.0f;
    public int statue = 0;
    // Start is called before the first frame update
    public mDialogue dialogue1;
    public mDialogue dialogue2;
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

            if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F))
            {
                GameObject.Find("dialogManager").GetComponent<dlgMgr>().DisplayNextSentence(gameObject);
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {


        if (gameObject.name == "Sheep")
        {
            GameObject.Find("dialogManager").GetComponent<dlgMgr>().StartDialogue(gameObject, statue);
            spriteObj.SetActive(true);

        }

        if (gameObject.name == "STAG"
          && GameObject.Find("Sheep").GetComponent<interactible>().statue == 1 
          && GameObject.Find("Player").GetComponent<transform3>().form == 1
        ){
            spriteObj.SetActive(true);
            GameObject.Find("dialogManager").GetComponent<dlgMgr>().StartDialogue(gameObject, statue);

        }


    }




    void OnTriggerExit(Collider other)
    {
        spriteObj.SetActive(false);
    }
}
