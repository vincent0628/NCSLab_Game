using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float thetaNaught = 90.0f;
    public float ratio = 3.0f;
    private float prev_theta;

    void Start()
    {
    }
    void FixedUpdate()
    { 
        float theta = thetaNaught * Mathf.Cos(Mathf.Sqrt(ratio) * Time.time);
        transform.eulerAngles = new Vector3(0, 0,theta);
    }
}
