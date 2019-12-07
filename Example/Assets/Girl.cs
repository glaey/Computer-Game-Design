using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public GameObject[] penguins;
    private bool firstCall = true;
    private AudioSource[] audioSource;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        audioSource = transform.parent.gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            particleSystem.Play(false);
            particleSystem.loop = true;
            Call();
            audioSource[0].Play();
            audioSource[0].loop = true;
        }
        else if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.JoystickButton1))
        {
            
            Call();
        }
        else if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            particleSystem.loop = false;
            audioSource[0].Stop();
            audioSource[1].loop = false;
           
        }
    }

    void Call()
    {
        
        if(firstCall == true)
        {
            penguins = GameObject.FindGameObjectsWithTag("Baby");
            firstCall = false;
        }
        for (int i = 0; i < penguins.Length; i++)
        {
            penguins[i].GetComponent<Call>().Move(transform.position);
        }
    }
}
