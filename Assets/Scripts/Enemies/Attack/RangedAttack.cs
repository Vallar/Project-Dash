using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyAttack {

    void Awake()
    {
        stats = GetComponent<EnemyStats>();
    }

    public override void Attack()
    {
        SpawnManager.instance.SpawnProjectile(GameManager.instance.player.transform.position, stats.damage);
    }
}