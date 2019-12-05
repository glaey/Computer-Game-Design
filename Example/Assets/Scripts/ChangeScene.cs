using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public bool toLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F))
        {
            if (toLevel)
            {
                StartCoroutine(LoadLevel());
            }
            else
            {
                StartCoroutine(LoadMainLevel());
            }
        }
    }

    IEnumerator LoadLevel ()
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
        GameObject.Find("GameState").SetActive(false);
    }

    IEnumerator LoadMainLevel()
    {
        string tmpname = SceneManager.GetActiveScene().name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Presentation2"));
        yield return null;
        GameObject.Find("Manager").GetComponent<SceneState>().sceneState.SetActive(true);
        SceneManager.UnloadSceneAsync(tmpname);
    }
}
