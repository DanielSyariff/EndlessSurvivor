using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupObject : MonoBehaviour, IPickupObject
{
    [SerializeField] int coinAmount;
    public void OnPickUp(Character character)
    {
        character.coins.Add(coinAmount);
    }
}
