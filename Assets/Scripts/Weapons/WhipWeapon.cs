using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMovement playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            //Debug.Log(colliders[i].gameObject.name);
            IDamageable e = colliders[i].GetComponent<IDamageable>();

            if (e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rightWhipObject.transform.position, whipAttackSize);
        Gizmos.DrawWireCube(leftWhipObject.transform.position, whipAttackSize);
    }

    public override void Attack()
    {
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
}
