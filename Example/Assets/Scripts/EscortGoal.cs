using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscortGoal : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Baby")
        {
            StartCoroutine(CompleteLevel());
        }
    }

    IEnumerator CompleteLevel()
    {
        string tmpname = SceneManager.GetActiveScene().name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Xboxtransform"));
        yield return null;
        GameObject.Find("Manager").GetComponent<SceneState>().sceneState.SetActive(true);
        GameObject.Find("Manager").GetComponent<SceneState>().completeLevel(level);
        SceneManager.UnloadSceneAsync(tmpname);
    }
}
