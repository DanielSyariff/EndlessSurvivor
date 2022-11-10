using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rgbd2d;

    [SerializeField] int baseHp = 5;
    [SerializeField] int healthPoint;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = target.gameObject;
        ResetStatus();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        healthPoint -= damage;

        if (healthPoint < 1)
        {
            this.gameObject.SetActive(false);
            ResetStatus();
        }
    }

    public void ResetStatus()
    {
        healthPoint = baseHp;
    }
}
