using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Spikes")]
public class SpikesAbility : Ability {

    protected override void ApplyEffect()
    {
        playerStats.isSpikes = true;
    }

    protected override void RemoveEffect()
    {
        playerStats.isSpikes = false;
    }
}