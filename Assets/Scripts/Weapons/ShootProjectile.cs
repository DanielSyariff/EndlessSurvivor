using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerMovement playerMove;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int bulletAmount;
    float timeInterval;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnProjectile();
        }

        //if (timer < timeToAttack)
        //{
        //    timer += Time.deltaTime;
        //    return;
        //}

        //timer = 0;
        //SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        //timer = timeToAttack;
        //GameObject shoot = Instantiate(projectilePrefab);
        //shoot.transform.position = transform.position;
        //shoot.GetComponent<EnergyProjectile>().SetDirection(playerMove.lastHorizontalVector, 0);

        StartCoroutine(SpawnProjectiles());
    }

    IEnumerator SpawnProjectiles()
    {
        timer = timeToAttack;
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject shoot = Instantiate(projectilePrefab);
            shoot.transform.position = transform.position;
            shoot.GetComponent<EnergyProjectile>().SetDirection(playerMove.lastHorizontalVector, 0);
            yield return new WaitForSeconds(0.2f);
        }
        //timer = timeToAttack;

    }
}
