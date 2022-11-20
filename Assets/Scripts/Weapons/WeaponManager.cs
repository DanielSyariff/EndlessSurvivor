using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Transform weaponsObjectController;
    [SerializeField] WeaponData startingWeapon;

    [SerializeField] List<WeaponBase> weapons;

    private void Awake()
    {
        character = GetComponent<Character>();
        weapons = new List<WeaponBase>();
    }

    private void Start()
    {
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponsObjectController.transform);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        Level level = GetComponent<Level>();

        //Add Weapon Upgrade ke List Upgrade di Level
        if (level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }

    //internal void AddStatusToCharacter(UpgradeData upgradeData)
    //{
    //    WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
    //    weaponToUpgrade.UpgradeToCharacterStatus(character, upgradeData);
    //}

    //Search Weapon yang akan di Upgrade berdasarkan List yang sudah di Add di "weapons" dari Fungsi AddWeapon
    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        //Cari SO WeaponData yang sama dengan Selected Upgrade SO Weapon
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
