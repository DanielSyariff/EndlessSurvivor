using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemStats
{
    public int armor;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor; 
    }
}

[CreateAssetMenu(fileName = "Item", menuName = "Survivor/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void init(string name)
    {
        this.Name = name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    public void Equip(Character character)
    {
        character.armor += stats.armor;
    }

    public void UnEquip(Character character)
    {
        character.armor -= stats.armor;
    }
}
