using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class StationaryRanged : MonoBehaviour {

    private EnemyStats stats;
    private EnemyAttack attack;
    
    void Awake()
    {
        stats = GetComponent<EnemyStats>();
        attack = GetComponent<EnemyAttack>();
    }

    void Start()
    {
        Timing.RunCoroutine(StartAttackRoutine());
    }

    private IEnumerator<float> StartAttackRoutine()
    {
        yield return Timing.WaitForSeconds(stats.tellTimer);

        attack.Attack();

        yield return Timing.WaitForSeconds(stats.actionRechargeTime);

        Timing.RunCoroutine(StartAttackRoutine());
    }

}