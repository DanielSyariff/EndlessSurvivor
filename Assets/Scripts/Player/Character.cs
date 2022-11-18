using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHP;

    public float speed = 3f;
    [SerializeField] [Range(0f, 100f)] public float critRate;

    public int armor;

    public float hpDegenerationRate = 1f;
    public float hpRegenerationTimer;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    private bool isDead;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    private void Start()
    {
        currentHP = maxHp;
        hpBar.SetState(currentHP, maxHp);
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpDegenerationRate;

        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1;
        }
    }

    public void TakeDamage(int damage)
    {

        if (isDead == true)
        {
            return;
        }
        //ApplyArmor(ref damage);

        currentHP -= damage;

        if (currentHP <= 0)
        {
            Debug.Log("CHARACTER IS DEAD, GAME OVER");
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;

        }

        hpBar.SetState(currentHP, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0)
        {
            damage = 0;
        }
    }

    public void Heal(int amount)
    {
        if (currentHP <= 0)
        {
            return;
        }

        currentHP += amount;
        if (currentHP > maxHp)
        {
            currentHP = maxHp;
        }

        hpBar.SetState(currentHP, maxHp);
    }
}
