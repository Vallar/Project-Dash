using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class MeleeBash : EnemyAttack {

    public override void Attack()
    {
        Timing.RunCoroutine(StartAttack());
    }

    private IEnumerator<float> StartAttack()
    {
        yield return Timing.WaitForSeconds(stats.tellTimer);

        //TODO: Show explosion with bells and whistles.

        if (Vector2.Distance(t.position, GameManager.instance.player.transform.position) <= stats.attackRange)
            GameManager.instance.player.GetComponent<PlayerStats>().ReduceHealth(stats.damage);
    }
}