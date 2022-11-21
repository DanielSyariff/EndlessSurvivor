using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyStats
{
    public int baseHp = 5;
    public int healthPoint;
    public int damage = 1;
    public float speed;

    public EnemyStats(EnemyStats getEnemyStats)
    {
        this.baseHp = getEnemyStats.baseHp;
        this.healthPoint = this.baseHp;
        this.damage = getEnemyStats.damage;
        this.speed = getEnemyStats.speed;
    }

    internal void ApplyProgress(float progress)
    {
        this.baseHp = (int)(baseHp * progress);
        this.healthPoint = baseHp;
        this.damage = (int)(damage * progress);
        Debug.Log("Progress : " + progress);
    }
    
}

public class Enemy : MonoBehaviour, IDamageable
{
    private SpriteRenderer sp;

    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;

    Rigidbody2D rgbd2d;

    public EnemyStats enemyStats;

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

    internal void SetStatus(EnemyStats getEnemyStats)
    {
        enemyStats = new EnemyStats(getEnemyStats);
    }

    internal void UpdateStatsForProgress(float progress)
    {
        enemyStats.ApplyProgress(progress);
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * enemyStats.speed;
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

        targetCharacter.TakeDamage(enemyStats.damage);
    }

    public void TakeDamage(int damage)
    {
        enemyStats.healthPoint -= damage;

        Debug.Log("Status : " + enemyStats.healthPoint);

        if (enemyStats.healthPoint < 1)
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
        enemyStats.healthPoint = enemyStats.baseHp;
    }
}
