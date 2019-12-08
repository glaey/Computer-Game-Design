using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public SceneMngr scnMngr;
    public bool isMainLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (!isMainLevel)
        {

            scnMngr = GameObject.Find("SceneMngr").gameObject.GetComponent<SceneMngr>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            if (isMainLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                scnMngr.Restart();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Baby"  || collider.gameObject.tag == "Critter" || collider.transform.parent.tag == "Player")
        {
            if (isMainLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } else
            {
                scnMngr.Restart();
            }
        }
    }
}
