using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Double Distance")]
public class DoubleDistanceAbility : Ability
{

    protected override void ApplyEffect()
    {
        playerStats.range += data.effectAmount;
    }

    protected override void RemoveEffect()
    {
        playerStats.range -= data.effectAmount;
    }
}
