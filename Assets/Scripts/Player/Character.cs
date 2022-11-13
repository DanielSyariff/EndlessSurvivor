using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHP;
    [SerializeField] StatusBar hpBar;

    private void Start()
    {
        currentHP = maxHp;
        hpBar.SetState(currentHP, maxHp);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Debug.Log("CHARACTER IS DEAD, GAME OVER");
        }

        hpBar.SetState(currentHP, maxHp);
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
