using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            particleSystem.Play();
            GameObject[] critters = GameObject.FindGameObjectsWithTag("Critter");
            for(int i= 0; i < critters.Length; i++)
            {
                Vector3 moveDir = (critters[i].transform.position - transform.position).normalized;
                critters[i].GetComponent<Critter>().Move(moveDir);
            }
        }
    }
}
