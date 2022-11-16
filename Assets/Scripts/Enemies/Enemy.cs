using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private SpriteRenderer sp;

    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rgbd2d;

    [SerializeField] int baseHp = 5;
    [SerializeField] int healthPoint;
    [SerializeField] int damage = 1;
    [SerializeField] int experienceReward = 400;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
        ResetStatus();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
        TurnDirection();
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
            //targetGameObject.GetComponent<Level>().AddExperience(experienceReward);
            //this.gameObject.SetActive(false);
            Destroy(gameObject);
            GetComponent<DropOnDestroy>().CheckDrop();
            ResetStatus();
        }
    }

    public void TurnDirection()
    {
        if (transform.position.x > targetDestination.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }

    public void ResetStatus()
    {
        healthPoint = baseHp;
    }
}
