using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickupObject : MonoBehaviour, IPickupObject
{
    [SerializeField] int expAmount;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(expAmount);
    }
}
