using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : MonoBehaviour
{
    public GameObject sceneState;
    public bool[] levels = new bool[5];
    // Start is called before the first frame update
    void Start()
    {
        sceneState = transform.Find("GameState").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void completeLevel(int level)
    {
        levels[level] = true;
    }
}
