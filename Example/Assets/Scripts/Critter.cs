using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour
{
    ParticleSystem particleSystem;
    Animator animator;
    Vector3 _moveDir;
    public float speed;
    bool scared = false;
    float scareSum = 0;
    float scareDur;
    public float scaredCoef = 1f;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scared)
        {
            Move();
            scareSum += Time.deltaTime;
            if(scareSum > scareDur)
            {
                scared = false;
                scareSum = 0;
                animator.SetBool("isRunning", false);
            }
        }
    }

    public void Move()
    {
        transform.position += _moveDir * speed * Time.deltaTime;
    }

    public void Scare(Vector3 moveDir, float duration)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z), new Vector3(0,1f,0));
        particleSystem.Play();
        _moveDir = moveDir;
        scareDur = duration * scaredCoef;
        scared = true;
        animator.SetBool("isRunning", true);
    }

    public void Stop()
    {
        scared = false;
        scareSum = 0;
        animator.SetBool("isRunning", false);
    }
}
