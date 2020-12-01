using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableProjectile : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 15f;
	public GameObject owner;

	// Start is called before the first frame update
    void Start()
    {
		GetComponent<Rigidbody2D>().velocity = direction * speed;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if ( !hasHit) {
			float vx = GetComponent<Rigidbody2D>().velocity.x;
			float vy = GetComponent<Rigidbody2D>().velocity.y;
			direction.y  = vy / speed;
			GetComponent<Rigidbody2D>().velocity = direction * speed;
			float ang = Mathf.Atan2(vy, vx);
			GetComponent<Rigidbody2D>().rotation = Mathf.Rad2Deg * ang - 90.0f;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
			Destroy(gameObject);
		}
		else if ( owner != null && collision.gameObject != owner && collision.gameObject.tag == "Enemy" )
		{
			collision.gameObject.SendMessage("ApplyDamage", Mathf.Sign(direction.x) * 2f);
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}
}
