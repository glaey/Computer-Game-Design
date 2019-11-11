using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movement = 5.0f;
    public float aerialMovement = 1.0f;
    public float turnSpeed = 20.0f;
    public float jumpVelocity = 5.0f;
    Animator m_Animator;
    Rigidbody m_RigidBody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    bool canJump = true;
    Vector3 driftMovement;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        if (canJump == true)
        {
            if(Input.GetAxis("Jump") != 0)
            {
                m_Animator.SetBool("IsJumping", true);
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, jumpVelocity, m_RigidBody.velocity.z);
                canJump = false;
                driftMovement = m_Movement;
            } 
        } else {
            m_Animator.SetBool("IsJumping", false);
            driftMovement.x += aerialMovement * m_Movement.x;
            driftMovement.z += aerialMovement * m_Movement.z;
            /*
            if(driftMovement.x > movement)
            {
                driftMovement.x = movement;
            } else if (driftMovement.x < -movement){
                driftMovement.x = -movement;
            }
            if (driftMovement.z > movement)
            {
                driftMovement.z = movement;
            }
            else if (driftMovement.z < -movement)
            {
                driftMovement.z = -movement;
            }*/
            driftMovement.Normalize();
        }
    }

    void OnAnimatorMove()
    {
        if (canJump)
        {
            m_RigidBody.MovePosition(m_RigidBody.position + m_Movement * movement * Time.deltaTime);
        } else
        {
            m_RigidBody.MovePosition(m_RigidBody.position + driftMovement * movement * Time.deltaTime);
        }
        m_RigidBody.MoveRotation(m_Rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            canJump = true;
            m_Movement.Set(0f, 0f, 0f);
        }
        if(collision.gameObject.tag == "Pickup")
        {
            if (collision.gameObject.GetComponent<item>().type == "Purple Mushroom"){
                inventory.GetComponent<inventory>().pickUpPurple();
            }
            Destroy(collision.gameObject);
        }
    }
}
