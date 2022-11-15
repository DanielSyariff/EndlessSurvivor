using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHP;

    public int armor;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

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

    public void TakeDamage(int damage)
    {
        ApplyArmor(ref damage);

        currentHP -= damage;

        if (currentHP <= 0)
        {
            Debug.Log("CHARACTER IS DEAD, GAME OVER");
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
