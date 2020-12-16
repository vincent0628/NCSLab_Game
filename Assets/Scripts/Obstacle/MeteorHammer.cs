using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHammer : MonoBehaviour
{
    public float thetaNaught = 90.0f;
    public float frequency = 3.0f;
    private Transform attackCheck;
    private Rigidbody2D m_Rigidbody2D;
    private float force = 50.0f;
    void Start()
    {
    }
    void FixedUpdate()
    { 
        float theta = thetaNaught * Mathf.Cos(Mathf.Sqrt(frequency) * Time.time);
        transform.eulerAngles = new Vector3(0, 0,theta);
        HammerAttack();
    }
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        attackCheck = transform.Find("AttackCheck").transform;
    }

    public void HammerAttack()
    {
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 2f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Player")
            {
                collidersEnemies[i].gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, attackCheck.position, force);
            }
        }
    }
}
