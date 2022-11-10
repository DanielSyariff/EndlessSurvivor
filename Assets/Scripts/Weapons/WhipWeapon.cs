using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{

    [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMovement playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);

    [SerializeField] int whipDamage = 1;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            //Detecting Object
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            //Detecting Object
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            //Debug.Log(colliders[i].gameObject.name);
            Enemy e = colliders[i].GetComponent<Enemy>();

            if (e != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rightWhipObject.transform.position, whipAttackSize);
        Gizmos.DrawWireCube(leftWhipObject.transform.position, whipAttackSize);
    }
}
