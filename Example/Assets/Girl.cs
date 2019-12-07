using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public GameObject[] penguins;
    private bool firstCall = true;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            particleSystem.Play(false);
            particleSystem.loop = true;
            Call();
        }
        else if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.JoystickButton1))
        {
            
            Call();
        }
        else if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            particleSystem.loop = false;
           
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
