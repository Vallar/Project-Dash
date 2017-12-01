using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class MeleeTeleporter : MonoBehaviour {

    private EnemyStats stats;
    private EnemyMovement movement;
    private EnemyAttack attack;

    
    void Awake()
    {
        stats = GetComponent<EnemyStats>();
        attack = GetComponent<EnemyAttack>();
        movement = GetComponent<EnemyMovement>();
    }

    void OnEnable()
    {
        Timing.RunCoroutine(StartAttackRoutine());
    }

    private IEnumerator<float> StartAttackRoutine()
    {
        yield return Timing.WaitForSeconds(stats.actionRechargeTime);

        movement.Move(GameManager.instance.player.transform.position);

        yield return Timing.WaitForSeconds(stats.tellTimer);

        attack.Attack();

        yield return Timing.WaitForSeconds(stats.actionRechargeTime);

        Timing.RunCoroutine(StartAttackRoutine());
    }
}