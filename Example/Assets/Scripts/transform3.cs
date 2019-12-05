using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform3 : MonoBehaviour
{
    public GameObject lp;
    public GameObject bear;
    public GameObject stag;
    public GameObject wolf;

    private Quaternion lastRotation;
    private Vector3 moveDirection;
    public int form = 0;
    public bool dpad = true;


// Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        lp = transform.GetChild(0).gameObject;
        lp.SetActive(false);
        lp.SetActive(true);

        stag = transform.GetChild(1).gameObject;
        stag.SetActive(false);

        bear = transform.GetChild(2).gameObject;
        bear.SetActive(false);

        wolf = transform.GetChild(3).gameObject;
        wolf.SetActive(false);
    }

// Update is called once per frame
    void Update()
    {
        movePlayer();
        if (dpad)
        {
            checkShapeShiftDpad();
        } else
        {
            checkShapeShift();
        }
    }

    void movePlayer()
    {
        if (form == 0)
        {
            transform.position = lp.transform.position;
            lastRotation = lp.transform.rotation;
            moveDirection = lp.GetComponent<move2>()._moveDirection;
        }
        else if (form == 1)
        {
            transform.position = stag.transform.position;
            lastRotation = stag.transform.rotation;
            moveDirection = stag.GetComponent<move2>()._moveDirection;
        }
        else if(form == 2)
        {
            transform.position = bear.transform.position;
            lastRotation = bear.transform.rotation;
            moveDirection = bear.GetComponent<move2>()._moveDirection;
        } else
        {
            transform.position = wolf.transform.position;
            lastRotation = wolf.transform.rotation;
            moveDirection = wolf.GetComponent<move2>()._moveDirection;
        }
    }
    
    void checkShapeShiftDpad()
    {
        if (Input.GetAxis("DPad X") > 0.3)
        {
            form = 1;
            stag.transform.position = transform.position;
            stag.transform.rotation = lastRotation;
            stag.GetComponent<move2>()._moveDirection = moveDirection;
            lp.SetActive(false);
            bear.SetActive(false);
            stag.SetActive(true);
            wolf.SetActive(false);
        }
        else if (Input.GetAxis("DPad Y") > 0.3)
        {
            form = 0;
            lp.transform.position = transform.position;
            lp.transform.rotation = lastRotation;
            lp.GetComponent<move2>()._moveDirection = moveDirection;
            lp.SetActive(true);
            stag.SetActive(false);
            bear.SetActive(false);
            wolf.SetActive(false);
        }
        else if ((Input.GetAxis("DPad Y") < -0.3))
        {
            form = 2;
            bear.transform.position = transform.position;
            bear.transform.rotation = lastRotation;
            bear.GetComponent<move2>()._moveDirection = moveDirection;
            bear.SetActive(true);
            stag.SetActive(false);
            lp.SetActive(false);
            wolf.SetActive(false);
        }
        else if ((Input.GetAxis("DPad X") < -0.3))
        {
            form = 3;
            wolf.transform.position = transform.position;
            wolf.transform.rotation = lastRotation;
            wolf.GetComponent<move2>()._moveDirection = moveDirection;
            wolf.SetActive(true);
            stag.SetActive(false);
            lp.SetActive(false);
            bear.SetActive(false);
        }
    }

    void checkShapeShift()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.E))
        {
            form = (form + 1) % 4;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.Q))
        {
            form = (form - 1 + 4) % 4;
        }

        if(form == 1)
        {
            stag.transform.position = transform.position;
            stag.transform.rotation = lastRotation;
            stag.GetComponent<move2>()._moveDirection = moveDirection;
            lp.SetActive(false);
            bear.SetActive(false);
            stag.SetActive(true);
            wolf.SetActive(false);
        } else if (form == 0)
        {
            lp.transform.position = transform.position;
            lp.transform.rotation = lastRotation;
            lp.GetComponent<move2>()._moveDirection = moveDirection;
            lp.SetActive(true);
            stag.SetActive(false);
            bear.SetActive(false);
            wolf.SetActive(false);
        } else if(form == 2)
        {
            bear.transform.position = transform.position;
            bear.transform.rotation = lastRotation;
            bear.GetComponent<move2>()._moveDirection = moveDirection;
            bear.SetActive(true);
            stag.SetActive(false);
            lp.SetActive(false);
            wolf.SetActive(false);
        } else
        {
            wolf.transform.position = transform.position;
            wolf.transform.rotation = lastRotation;
            stag.GetComponent<move2>()._moveDirection = moveDirection;
            wolf.SetActive(true);
            stag.SetActive(false);
            lp.SetActive(false);
            bear.SetActive(false);
        }
    }
}
