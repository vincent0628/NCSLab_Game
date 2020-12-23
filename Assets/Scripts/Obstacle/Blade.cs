using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float travelingDistance = 300.0f;
    public float frequency = 2.0f;
    private Rigidbody2D m_Rigidbody2D;
    private float force = 40.0f;

    public enum Direction {
        Horizontal,
        Vertical
    }
    public Direction direction;
    private float rotationSpeed = 400.0f;
    private Vector3 originPosition;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        if (direction == Direction.Horizontal)
            moveDirection = new Vector3(1, 0, 0);
        else if (direction == Direction.Vertical)
            moveDirection = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originPosition + travelingDistance * Mathf.Cos(frequency * Time.time) * moveDirection;
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        BladeAttack();
    }
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void BladeAttack()
    {
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(transform.position, 2f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Player")
            {
                collidersEnemies[i].gameObject.GetComponent<CharacterController2D>().ApplyDamage(1f, transform.position, force);
            }
        }
    }
}
