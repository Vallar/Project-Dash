using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class SlowBrute : MonoBehaviour {

    private bool inPlayerRange = false;
    private EnemyStats stats;
    private EnemyMovement movement;
    private EnemyAttack attack;
    private Transform t;

    
    void Awake()
    {
        stats = GetComponent<EnemyStats>();
        attack = GetComponent<EnemyAttack>();
        movement = GetComponent<EnemyMovement>();
        t = transform;
    }

    void OnEnable()
    {
        inPlayerRange = false;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(t.position, GameManager.instance.player.transform.position) > stats.attackRange && inPlayerRange == false)
            movement.Move(GameManager.instance.player.transform.position);
    }

    public void AttackPlayer()
    {
        Timing.RunCoroutine(AttackRoutine());
    }

    private IEnumerator<float> AttackRoutine()
    {
        inPlayerRange = true;
        attack.Attack();

        yield return Timing.WaitForSeconds(stats.actionRechargeTime);

        if (Vector2.Distance(t.position, GameManager.instance.player.transform.position) > stats.attackRange)
            inPlayerRange = false;
        else
            Timing.RunCoroutine(AttackRoutine());
    }

}