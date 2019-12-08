using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    Rigidbody rigidbody;
    private bool recentlyMoved;
    public float timeSum;
    public float buffer = 0.7f;
    public bool isCube = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recentlyMoved)
        {
            timeSum += Time.deltaTime;
            if (timeSum > buffer)
            {
                recentlyMoved = false;
                timeSum = 0f;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bear" && (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Joystick1Button1) )&& !recentlyMoved)
        {
            Vector2 dif = new Vector2(other.gameObject.transform.position.x - gameObject.transform.position.x, other.gameObject.transform.position.z - gameObject.transform.position.z);
            float angle = Vector2.SignedAngle(new Vector2(1f,0f), dif);
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
            rigidbody.AddForce(Mathf.Cos(angle * Mathf.PI / 180) * -3000000f, 0f, Mathf.Sin(angle * Mathf.PI / 180)*-3000000f);
            recentlyMoved = true;
        }
    }

    void OnCollisionExit()
    {
        if (isCube)
        {
            rigidbody.velocity = new Vector3(0f, -10f, 0f);
        }
        
    }

    void OnCollisionEnter()
    {
        if (isCube)
        {
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
