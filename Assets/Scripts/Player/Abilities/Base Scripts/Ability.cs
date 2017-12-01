using UnityEngine;
using System.Collections;
using MovementEffects;
using System.Collections.Generic;

public class Ability : ScriptableObject
{

    [SerializeField] protected AbilityData data;
    protected static PlayerStats playerStats;
    protected static Transform t;

    //protected virtual void Awake()
    //{
    //    playerStats = GetComponent<PlayerStats>();
    //}

    public static void InitializeAbility(PlayerStats _stats, Transform _t)
    {
        t = _t;
        playerStats = _stats;
    }

    public void FireAbility()
    {
        Timing.RunCoroutine(ActivateAbility());
    }

    protected IEnumerator<float> ActivateAbility()
    {
        if (data.isActive == false)
        {
            data.isActive = true;
            ApplyEffect();
        }
        else
        {
            //TODO: Show in UI it is inactive.
        }

        if (data.type == AbilityType.ACTIVE)
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(ActivateCooldown()));
            RemoveEffect();
        }
        else
            yield return 0;

    }

    protected IEnumerator<float> ActivateCooldown()
    {
        data.isActive = false;
        data.isRecharging = true;

        yield return Timing.WaitForSeconds(data.rechargeTime);

        data.isRecharging = false;
        data.isActive = false;
    }

    protected virtual void ApplyEffect() { }

    protected virtual void RemoveEffect() { }
}
