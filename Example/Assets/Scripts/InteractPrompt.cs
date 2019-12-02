using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPrompt : MonoBehaviour
{
    Vector3 position;
    public GameObject spriteObj;
    public float height = 1.0f;
    GameObject x;
    // Start is called before the first frame update
    void Start()
    {
        x = (GameObject) Instantiate(spriteObj);
        x.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
        x.transform.position = gameObject.transform.position + new Vector3(0f, height, 0f);
        x.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Player")
        {
            x.SetActive(true);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.tag == "Player")
        {
            x.SetActive(false);
        }
    }
}
