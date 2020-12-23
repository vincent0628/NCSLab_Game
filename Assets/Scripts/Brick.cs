﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("Chicken")) {
            ContactPoint2D contact = col.contacts[0];
            Debug.Log(contact.point.y);
            Debug.Log(transform.position.y);
            if(contact.point.y > transform.position.y+1.0) {
                Invoke("DropPlatform", 0.5f);
                Destroy(gameObject, 1f);
            }
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
