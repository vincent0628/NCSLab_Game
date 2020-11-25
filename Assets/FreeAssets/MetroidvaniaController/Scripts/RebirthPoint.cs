using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object enter the trigger");
    }
}
