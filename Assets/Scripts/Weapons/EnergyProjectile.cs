using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyProjectile : MonoBehaviour
{
    [SerializeField] public ShootProjectile shootProjectile;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    [SerializeField] public int damage = 5;

    [SerializeField] float applyDamageTimer = 1;
    float applyTimer = 0;

    [SerializeField] int lifeTime = 2;
    int gotHit;

    float dirX;
    float dirY;

    public void SetDirection(float dir_x, float dir_y)
    {
        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }

        if (dir_x > 0)
        {
            dirX = 1;
        }
        else
        {
            dirX = -1;
        }

        //if (dir_y > 0)
        //{
        //    dirY = 1;
        //}
        //else
        //{
        //    dirY = -1;
        //}

        direction = new Vector3(dirX, dirY);

    }

    bool hitDetected = true;

    private void Update()
    {
        if (hitDetected)
        {
            applyTimer -= Time.deltaTime;
        }

        transform.position += direction * speed * Time.deltaTime;

        if (applyTimer < 0f)
        {
            hitDetected = false;
            //applyTimer = applyDamageTimer;
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.2f);

            foreach (Collider2D c in hit)
            {
                IDamageable enemy = c.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    shootProjectile.ProjectileGiveDamage(damage, c.transform.position);
                    enemy.TakeDamage(damage);
                    gotHit++;
                    applyTimer = applyDamageTimer;
                    hitDetected = true;
                    break;
                }
            }

            if (gotHit >= lifeTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
