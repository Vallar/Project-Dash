using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Double Hope")]
public class DoubleHopeAbility : Ability
{
    protected override void ApplyEffect()
    {
        playerStats.isDoubleHope = true;
    }

    protected override void RemoveEffect()
    {
        playerStats.isDoubleHope = false;
    }
}
