using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;

	public GameObject particleDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!hasHit)
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.SendMessage("ApplyDamage", Mathf.Sign(direction.x) * 2f);
			GameObject destroyEffect = Instantiate(particleDestroy, collision.gameObject.transform.position, Quaternion.identity);
			destroyEffect.GetComponent<ParticleSystem>().Play();
			Destroy(gameObject);
			Destroy(destroyEffect, 1.0f);
		}
		else if (collision.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}
}
