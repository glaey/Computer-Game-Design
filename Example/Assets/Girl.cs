using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public GameObject[] penguins;
    // Start is called before the first frame update
    void Start()
    {
        penguins = GameObject.FindGameObjectsWithTag("Baby");
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            particleSystem.Play(false);
            particleSystem.loop = true;
            Call();
        }
        else if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.JoystickButton3))
        {
            
            Call();
        }
        else if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.JoystickButton3))
        {
            particleSystem.loop = false;
           
        }
    }

    void Call()
    {
        for (int i = 0; i < penguins.Length; i++)
        {
            penguins[i].GetComponent<Call>().Move(transform.position);
        }
    }
}
