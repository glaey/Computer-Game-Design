﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMotion : MonoBehaviour
{
    public float duration;
    public float angle = 360f;
    float rotation;
    Vector3 rotationCircle = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationCircle, -angle * Time.deltaTime / duration);
        rotation += angle * Time.deltaTime / duration;
        if (rotation >= angle)
        {
            rotation = 0;
            Destroy(gameObject);
        }
    }
}