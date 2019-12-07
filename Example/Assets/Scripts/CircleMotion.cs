using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMotion : MonoBehaviour
{
    public float duration;
    public float angle = 360f;
    float rotation;
    public bool infinite = false;
    Vector3 rotationCircle = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (infinite)
        {
            transform.Rotate(rotationCircle, -angle * Time.deltaTime / duration);
        } else
        {
            rotation += angle * Time.deltaTime / duration;
            if (rotation >= angle)
            {
                rotation = 0;
                Destroy(gameObject);
            }
        }
    }
}
