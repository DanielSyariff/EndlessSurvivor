using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponsObjectController;
    [SerializeField] WeaponData startingWeapon;

    private void Start()
    {
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponsObjectController.transform);
        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);

        Level level = GetComponent<Level>();

        //Add Weapon Upgrade ke List Upgrade di Level
        if (level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }
}
