﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public float roarRadius;
    public float roarCD;
    float timer;
    bool activeCD = false;
    Animator animator;
    move2 movement;
    private AudioSource[] audioSource;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<move2>();
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        audioSource = transform.parent.gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeCD)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                audioSource[3].Play();
                Howl();
                activeCD = true;
                animator.SetBool("isHowling", true);
            }
        } else
        {
            timer += Time.deltaTime;
            if(timer > roarCD)
            {
                activeCD = false;
                timer = 0;
                animator.SetBool("isHowling", false);
            }
        }
        
    }

    void Howl()
    {
        particleSystem.Play();
        GameObject[] critters = GameObject.FindGameObjectsWithTag("Critter");
        for (int i = 0; i < critters.Length; i++)
        {
            Vector3 positionDiff = (critters[i].transform.position - transform.position);
            if (positionDiff.magnitude < roarRadius)
            {
                critters[i].GetComponent<Critter>().Scare(positionDiff.normalized, (roarRadius - positionDiff.magnitude) / roarRadius);
            }
        }
    }
}
