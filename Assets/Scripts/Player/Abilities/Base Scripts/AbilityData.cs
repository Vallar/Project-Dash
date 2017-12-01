using UnityEngine;
using System.Collections;

public enum AbilityType { ACTIVE, PASSIVE}

[CreateAssetMenu]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public bool isActive = true;
    public bool isRecharging = false;
    public bool canBeBought;
    public AbilityType type;
    public float rechargeTime;
    public float activeTime;
    public float effectAmount;
    public int cost;
}
