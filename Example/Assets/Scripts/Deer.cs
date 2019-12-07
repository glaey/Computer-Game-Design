using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public bool isCharging = false;
    private float chargeProgress = 0;
    public float chargeDuration;
    public float chargeSpeed = 2.0f;
    public bool linerCharge = false;
    public float linearSpeed = 2.0f;
    public float chargeCD;
    public bool activeCD;
    private float timeSum = 0f;
    private Vector3 _moveDirection = Vector3.zero;
    private move2 movement;

    private CameraShake cameraShake;
    GameObject trials;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<move2>();
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        trials = GameObject.Find("Trials").gameObject;
        trials.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCD)
        {
            timeSum += Time.deltaTime;
            if (timeSum > chargeCD)
            {
                activeCD = false;
                timeSum = 0f;
            }
        }
        if (isCharging)
        {
            Charge();
            return;
        }
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1)) && !activeCD)
        {
            isCharging = true;
            movement.isCharging = true;
            _moveDirection = transform.forward * movement.speed;
            trials.SetActive(true);
        }
    }
    void OnEnable()
    {
        activeCD = false;
        timeSum = 0f;
    }

    private void Charge()
    {
        if (linerCharge)
        {
            movement._characterController.Move(_moveDirection * Time.deltaTime * linearSpeed);
            chargeProgress += linearSpeed * Time.deltaTime;
            if (chargeProgress > chargeDuration)
            {
                EndCharge(0f);
            }
        }
        else
        {
            movement._characterController.Move(_moveDirection * Time.deltaTime * Mathf.Pow(chargeProgress, 2));
            chargeProgress += chargeSpeed * Time.deltaTime;
            if (chargeProgress > chargeDuration)
            {
                EndCharge(0f);
            }
        }
    }

    public void EndCharge(float shakeDur)
    {
        movement.isCharging = false;
        isCharging = false;
        chargeProgress = 0f;
        cameraShake.startShaking(shakeDur);
        activeCD = true;
        trials.SetActive(false);
    }
}
