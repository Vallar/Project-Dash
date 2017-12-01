using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public int currentHP;
    public int damage;
    public float actionRechargeTime = 1f;
    public float tellTimer = 0.25f;
    public float attackRange;

    [SerializeField] private int maxHP;
    private Collider2D col;

    
    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void EnableEnemy()
    {
        col.enabled = true;
        currentHP = maxHP;
        gameObject.SetActive(true);
    }

    public void ReduceHealth(int _damage)
    {
        if (currentHP - _damage > 0)
        {
            currentHP -= _damage; 
            //TODO: UI show the HP and some bells and whistles.
        }
        else
        {
            GameManager.instance.enemiesKilled += 1;
            DisableEnemy();
        }
    }

    public void DisableEnemy()
    {
        col.enabled = false;
        gameObject.SetActive(false);
    }
}
