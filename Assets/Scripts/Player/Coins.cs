using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainer data;
    [SerializeField] TextMeshProUGUI coinsText;
    
    public void Add(int amount)
    {
        data.coins += amount;
        coinsText.text = "COINS : " + data.coins.ToString();
    }
}
