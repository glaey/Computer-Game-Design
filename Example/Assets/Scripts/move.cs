using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
  // Start is called before the first frame update
  private Animator _animator;
  private CharacterController _characterController;
  private float gravity = 20.0f;
  private bool isHit = false;

  private Vector3 _moveDirection = Vector3.zero;

  public float speed = 5.0f;
  public float rotationSpeed = 240.0f;
  public float JumpSpeed = 5.0f;

  public GameObject inventory;
  void Start()
  {
    _animator = GetComponent<Animator>();
    _characterController = GetComponent<CharacterController>();
    inventory = GameObject.Find("Inventory");

  }

  // Update is called once per frame
  void Update()
  {

    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    // Calculate the forward vector
    Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

    if (move.magnitude > 1f) move.Normalize();

    // Calculate the rotation for the player
    move = transform.InverseTransformDirection(move);

    // Get Euler angles
    float turnAmount = Mathf.Atan2(move.x, move.z);

    transform.Rotate(0, turnAmount * rotationSpeed * Time.deltaTime, 0);

    if (_characterController.isGrounded)
    {
      _moveDirection = transform.forward * move.magnitude;

      _moveDirection *= speed;
      if (Input.GetButton("Jump"))
      {
        _animator.SetBool("is_in_air", true);
        _moveDirection.y = JumpSpeed;

      }
      else
      {
        _animator.SetBool("is_in_air", false);
        _animator.SetBool("run", move.magnitude > 0);


        // Debug.Log(_animator.GetBool("run"));

      }
    }


    _moveDirection.y -= gravity * Time.deltaTime;

    _characterController.Move(_moveDirection * Time.deltaTime);



  }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    //check for a match with the specified name on any gameobject that collides with your gameobject
    //    // if (collision.gameobject.tag == "ground")
    //    // {
    //    //     //if the gameobject's name matches the one you suggest, output this message in the console
    //    //     canjump = true;
    //    //     m_movement.set(0f, 0f, 0f);
    //    // }

    //    if (hit.collider.gameObject.tag == "Pickup")
    //    {
    //        isHit = true;
    //        if (hit.collider.gameObject.GetComponent<item>().type == "Purple Mushroom")
    //        {
    //            inventory.GetComponent<inventory>().pickUpPurple();
    //        }
    //        print("collision out: " + hit.collider.gameObject.name);

    //        Destroy(hit.collider.gameObject);


    //    }
    //}
}


