using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<ItemData> items;

    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        
    }

    public void Equip(ItemData itemToEquip)
    {
        if (items == null)
        {
            items = new List<ItemData>();
        }

        ItemData newItemInstance = new ItemData();
        newItemInstance.init(itemToEquip.name);
        newItemInstance.stats.Sum(itemToEquip.stats);

        items.Add(newItemInstance);
        newItemInstance.Equip(character);
    }

    public void UnEquip(ItemData itemToUnequip)
    {

    }

    internal void UpgradeItem(UpgradeData upgradeData)
    {
        ItemData itemToUpgarde = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgarde.UnEquip(character);
        itemToUpgarde.stats.Sum(upgradeData.itemStats);
        itemToUpgarde.Equip(character);
    }
}
