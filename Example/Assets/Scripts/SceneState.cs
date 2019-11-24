using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : MonoBehaviour
{
    public GameObject sceneState;
    // Start is called before the first frame update
    void Start()
    {
        sceneState = transform.Find("GameState").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
