using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public bool tutorial;
    public bool toLevel;
    private bool activated;
    private float buffer = 1f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (timer > buffer)
        {
            if (other.transform.parent.tag == "Player" && (Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.F)))
            {
                activated = true;
            }
        }
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(timer > buffer)
        {
            if (other.transform.parent.tag == "Player" && (Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.F)))
            {
                activated = true;
            }
        }
    }
    
    void OnEnable()
    {
        activated = false;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (activated && timer > buffer)
        {
            activated = false;
            timer = 0;
            if (tutorial)
            {
                SceneManager.LoadScene(SceneName);
            }
            else
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
    }

    IEnumerator LoadLevel ()
    {
        print("loading level");
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
        GameObject.Find("GameState").SetActive(false);
    }

    IEnumerator LoadMainLevel()
    {
        string tmpname = SceneManager.GetActiveScene().name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
        yield return null;
        GameObject.Find("Manager").GetComponent<SceneState>().sceneState.SetActive(true);
        SceneManager.UnloadSceneAsync(tmpname);
    
    }
}
