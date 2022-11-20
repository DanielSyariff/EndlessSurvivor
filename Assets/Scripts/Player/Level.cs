using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;

    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] WeaponManager weaponManager;
    [SerializeField] PassiveItems passiveItems;

    //List Keseluruhan Upgrades
    [SerializeField] List<UpgradeData> upgrades;

    //List Upgrade yang terpilih berdasarkan Randomize
    [SerializeField] List<UpgradeData> selectedUpgrades;

    //List Weapon yang dimiliki Player saat bermain
    [SerializeField] List<UpgradeData> acquiredUpgrades;

    //List Item yang bisa dimiliki Player
    [SerializeField] List<UpgradeData> upgradesItemAvailableOnStart;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItems = GetComponent<PassiveItems>();
    }

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        AddUpgradesIntoTheListOfAvailableUpgrades(upgradesItemAvailableOnStart);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if (upgradesToAdd == null)
        {
            return;
        }

        upgrades.AddRange(upgradesToAdd);
    }

    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if (acquiredUpgrades == null)
        {
            acquiredUpgrades = new List<UpgradeData>();
        }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                //weaponManager.AddStatusToCharacter(upgradeData);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(upgradeData.item);
                AddUpgradesIntoTheListOfAvailableUpgrades(upgradeData.item.upgrades);
                break;
            default:
                break;
        }

        //Add Selected Upgrade ke List Acquired
        acquiredUpgrades.Add(upgradeData);

        //Remove Upgrade dari "upgrades" apabila sudah terpilih
        upgrades.Remove(upgradeData);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        if (selectedUpgrades == null)
        {
            selectedUpgrades = new List<UpgradeData>();
        }

        //Setiap Level Up, Clear Selected Upgrade sebelumnya, dan Ambil List baru dari upgrades
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        upgradeManager.OpenUpgradePanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        //Get Upgrade by Random sejumlah yg diambil
        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }
}
