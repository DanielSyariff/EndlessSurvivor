using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : WeaponBase
{
    PlayerMovement playerMove;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int bulletAmount;
    float timeInterval;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    public override void Attack()
    {
        StartCoroutine(SpawnProjectiles());
    }
    IEnumerator SpawnProjectiles()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject shoot = Instantiate(projectilePrefab);
            shoot.transform.position = transform.position;
            shoot.GetComponent<EnergyProjectile>().SetDirection(playerMove.lastHorizontalVector, 0);
            shoot.GetComponent<EnergyProjectile>().damage = weaponStats.damage;
            shoot.GetComponent<EnergyProjectile>().shootProjectile = this;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ProjectileGiveDamage(int damage, Vector3 position)
    {
        PostDamage(damage, position);
    }
}
