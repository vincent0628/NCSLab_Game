using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAttack : MonoBehaviour
{
	public float dmgValue = 4;
	public int throwableWeaponNum = 5;
	public GameObject throwableObject;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;
	public float startTimeBtwShots;
	private float timeBtwShots;
	public GameObject particleSpark;
	public GameObject particleDestroy;
	public GameObject cam;
	
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.X) && canAttack)
		{
			canAttack = false;
			animator.SetBool("IsAttacking", true);
			StartCoroutine(AttackCooldown());
		}

		//if (timeBtwShots <= 0)
		//{
		//	if (Input.GetKeyDown(KeyCode.V))
		//	{
		//		Quaternion rot = Quaternion.identity;
		//		rot.eulerAngles = new Vector3(0, 0, transform.localScale.x * -90);
		//		GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), rot) as GameObject; 
		//		Vector2 direction = new Vector2(transform.localScale.x, 0);
		//		throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
		//		throwableWeapon.GetComponent<ThrowableWeapon>().particleDestroy = particleDestroy;
		//		throwableWeapon.name = "ThrowableWeapon";
		//		timeBtwShots = startTimeBtwShots;
		//	}
		//}
		//else {
		//	timeBtwShots -= Time.deltaTime;
		//}

		if (Input.GetKeyDown(KeyCode.V))
		{
			if (throwableWeaponNum > 0)
			{
				Quaternion rot = Quaternion.identity;
				rot.eulerAngles = new Vector3(0, 0, transform.localScale.x * -90);
				StartCoroutine(Attack(rot));
				throwableWeaponNum--;
			}
		//	else
		//	{
		//		timeBtwShots -= Time.deltaTime;
		//	}
		}
	}

	IEnumerator Attack(Quaternion rot)
    {
		for (int i = 0; i < 5; i++)
		{
			GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), rot) as GameObject;
			Vector2 direction = new Vector2(transform.localScale.x, 0);
			throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
			throwableWeapon.GetComponent<ThrowableWeapon>().particleDestroy = particleDestroy;
			throwableWeapon.name = "ThrowableWeapon";
			timeBtwShots = startTimeBtwShots;
			yield return new WaitForSeconds(0.2f);
		}
	}

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
	}

	public void DoDashDamage()
	{
		Debug.Log("DoDashDamage()");
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
				GameObject sparkEffect = Instantiate(particleSpark, collidersEnemies[i].transform.position, Quaternion.identity);
				sparkEffect.GetComponent<ParticleSystem>().Play();
				Destroy(sparkEffect, 1.0f);
			}
			Debug.Log("Collision occured!!!!!");
		}
	}
}
