using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Increase Size")]
public class IncreaseSize : Ability
{
    protected override void ApplyEffect()
    {

        t.localScale *= data.effectAmount;
    }

    protected override void RemoveEffect()
    {
        t.localScale /= data.effectAmount;
    }
}
