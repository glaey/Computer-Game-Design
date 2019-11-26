using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMngr : MonoBehaviour
{
    public GameObject scene;
    // Start is called before the first frame update
    void Start()
    {
        //scene = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 1)
        {
            Destroy(transform.GetChild(0).gameObject);
            print("deleted extra");
        }
    }

    public void Restart()
    {
        var newScene = Instantiate(scene);
        newScene.transform.parent = transform;
        Destroy(transform.GetChild(0).gameObject);
    }
}
