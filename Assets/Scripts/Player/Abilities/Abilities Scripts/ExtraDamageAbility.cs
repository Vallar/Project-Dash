using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Extra Damage")]
public class ExtraDamageAbility : Ability {

    protected override void ApplyEffect()
    {
        playerStats.damage += (int)data.effectAmount;
    }
}