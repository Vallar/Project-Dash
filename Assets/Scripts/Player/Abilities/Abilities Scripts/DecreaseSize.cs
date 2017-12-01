using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Decrease Size")]
public class DecreaseSize : Ability
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
