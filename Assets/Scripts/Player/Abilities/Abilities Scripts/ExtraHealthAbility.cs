using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Extra Health")]
public class ExtraHealthAbility : Ability {

    protected override void ApplyEffect()
    {
        playerStats.maxHealth += (int)data.effectAmount;
    }
}