using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMotion : MonoBehaviour
{
    public float duration;
    float rotation;
    Vector3 rotationCircle = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationCircle, -360 * Time.deltaTime / duration);
        rotation += 360 * Time.deltaTime / duration;
        if (rotation >= 360)
        {
            rotation = 0;
            Destroy(gameObject);
        }
    }
}
