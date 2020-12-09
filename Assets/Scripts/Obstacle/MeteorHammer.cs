using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHammer : MonoBehaviour
{
    public float thetaNaught = 90.0f;
    public float frequency = 3.0f;

    void Start()
    {
    }
    void FixedUpdate()
    { 
        float theta = thetaNaught * Mathf.Cos(Mathf.Sqrt(frequency) * Time.time);
        transform.eulerAngles = new Vector3(0, 0,theta);
    }
}
