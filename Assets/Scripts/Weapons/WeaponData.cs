using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    //For Range Attack and Have Bullet Only
    [Header("If Have Bulllet Only")]
    public int bulletAmount;

    public WeaponStats(int damage, float timeToAttack, int bullet)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.bulletAmount = bullet;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.bulletAmount += weaponUpgradeStats.bulletAmount;
    }
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Survivor/Weapon")]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}
