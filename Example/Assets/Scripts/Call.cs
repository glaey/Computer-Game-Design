﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : MonoBehaviour
{
    public GameObject target;
    public float speed;
    Animator animator;
    bool ismoving;
    public float minDis;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.JoystickButton3))
        {
            gameObject.transform.position = gameObject.transform.position + ((target.gameObject.transform.position - gameObject.transform.position).normalized * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation((target.gameObject.transform.position - gameObject.transform.position), new Vector3(0, 1f, 0));
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
        }*/
        if (ismoving)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        ismoving = false;
    }

    public void Move(Vector3 target)
    {
        if(Vector3.Distance(gameObject.transform.position, target) > minDis)
        {
            gameObject.transform.position = gameObject.transform.position + ((target - gameObject.transform.position).normalized * speed * Time.deltaTime);
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }
        transform.rotation = Quaternion.LookRotation(new Vector3(target.x - gameObject.transform.position.x, 0f , target.z - gameObject.transform.position.z), new Vector3(0, 1f, 0));
    }
}
