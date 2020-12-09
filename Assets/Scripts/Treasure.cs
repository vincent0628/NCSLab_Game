using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour {

    [SerializeField]

    private bool pickUpAllowed;
	private GameObject Chicken;
	// Use this for initialization
	private void Start () {
		pickUpAllowed = false;
        Chicken = GameObject.Find("Chicken");
	}
	
	// Update is called once per frame
	private void Update () {
        if (pickUpAllowed)
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Chicken"))
        {
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Chicken"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
        Chicken.transform.GetChild(7).gameObject.SetActive(true);
    }
}
