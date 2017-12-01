using UnityEngine;
using System.Collections;

public class BoomerangEnemy : MonoBehaviour
{

    private EnemyMovement movement;

    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
    }

    void Start()
    {
        movement.Move(GameManager.instance.player.transform.position);
    }
}
