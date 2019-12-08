using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractGoal : MonoBehaviour
{
    public int level;
    public string mainLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Player" && (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F)))
        {
            StartCoroutine(CompleteLevel());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.tag == "Player" && (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F)))
        {
            StartCoroutine(CompleteLevel());
        }
    }

    IEnumerator CompleteLevel()
    {
        string tmpname = SceneManager.GetActiveScene().name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(mainLevel));
        yield return null;
        GameObject.Find("Manager").GetComponent<SceneState>().sceneState.SetActive(true);
        GameObject.Find("Manager").GetComponent<SceneState>().completeLevel(level);
        SceneManager.UnloadSceneAsync(tmpname);
    }
}
