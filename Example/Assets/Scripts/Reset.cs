using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public SceneMngr scnMngr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        scnMngr = GameObject.Find("SceneMngr").gameObject.GetComponent<SceneMngr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Baby"  || collider.gameObject.tag == "Bear" || collider.transform.parent.tag == "Player")
        {
            scnMngr.Restart();
        }
    }
}
