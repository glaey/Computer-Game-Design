using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutout : MonoBehaviour
{
    float cutout = 0f;
    public float duration;
    Material m;
    // Start is called before the first frame update
    void Start()
    {
        m = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        m.SetFloat("_Cutoff", cutout);
        cutout += Time.deltaTime / duration;
    }
}
