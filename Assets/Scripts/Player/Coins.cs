using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TextMeshProUGUI coinsText;
    
    public void Add(int amount)
    {
        coinAcquired += amount;
        coinsText.text = "COINS : " + coinAcquired.ToString();
    }
}
