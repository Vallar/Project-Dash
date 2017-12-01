using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Shield")]
public class ShieldAbility : Ability
{
    protected override void ApplyEffect()
    {
        playerStats.isShield = true;
    }

    protected override void RemoveEffect()
    {
        playerStats.isShield = false;
    }
}
