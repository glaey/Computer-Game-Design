using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
    public GameObject player;
    Vector3 offset;
    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    public void startShaking(float dur)
    {
        shakeDuration = dur;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
        if (shakeDuration > 0)
        {
            transform.position += Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
        }
    }
}