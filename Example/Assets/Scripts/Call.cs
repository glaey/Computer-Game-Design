using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : MonoBehaviour
{
    public GameObject target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            gameObject.transform.position = gameObject.transform.position + ((target.gameObject.transform.position - gameObject.transform.position).normalized * speed * Time.deltaTime);
        }
    }
}
