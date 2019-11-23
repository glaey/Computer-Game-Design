using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Baby"  || collider.gameObject.tag == "Bear" || collider.gameObject.tag == "Stag" || collider.gameObject.tag == "Human")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
