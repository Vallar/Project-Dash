using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance = null;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bosses;
    [SerializeField] private GameObject hopePrefab;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int enemyTypeCount = 10;
    [SerializeField] private int projectileCount = 10;
    private List<EnemyStats> enemiesPool = new List<EnemyStats>();
    private List<EnemyStats> bossesPool = new List<EnemyStats>();
    private List<Projectile> projectilesPool = new List<Projectile>();
    private List<GameObject> hopesPool = new List<GameObject>();
    private Transform t;

    void Awake()
    {
        instance = this;
        t = transform;

        InitiatePools();
    }

    public void InitiatePools()
    {   
        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < enemyTypeCount; j++)
            {
                GameObject go = Instantiate(enemies[i], t.position, Quaternion.identity);
                EnemyStats s = go.GetComponent<EnemyStats>();
                s.DisableEnemy();
                enemiesPool.Add(s);
            }
        }

        for (int i = 0; i < bosses.Length; i++)
        {
            GameObject go = Instantiate(enemies[i], t.position, Quaternion.identity);
            EnemyStats s = go.GetComponent<EnemyStats>();
            s.DisableEnemy();
            bossesPool.Add(s);
        }

        for (int i = 0; i < projectileCount; i++)
        {
            GameObject go = Instantiate(projectilePrefab, t.position, Quaternion.identity);
            Projectile p = go.GetComponent<Projectile>();
            p.DisableProjectile();
            projectilesPool.Add(p);
        }

        for (int i = 0; i < projectileCount * 3; i++)
        {
            GameObject go = Instantiate(hopePrefab, t.position, Quaternion.identity);
            go.SetActive(false);
            hopesPool.Add(go);
        }
    }

    public void SpawnEnemy(int _index, Vector2 _position)
    {
        for (int i = 0; i < _index + enemyTypeCount; i++) // This is because the list starts at index 0 it works.
        {
            if (enemiesPool[i].gameObject.activeInHierarchy)
            {
                enemiesPool[i].EnableEnemy();
                if (_position != Vector2.zero)
                    enemiesPool[i].transform.position = _position;
                GameManager.instance.currentEnemiesCount += 1;
                return;
            }
        }
    }

    public void SpawnBoss(int _index)
    {
        bossesPool[_index].transform.position = Vector2.zero;
        bossesPool[_index].EnableEnemy();
        GameManager.instance.currentEnemiesCount += 1;
    }

    public void SpawnWave(int _enemiesCountInWave, int _enemyTypeCount)
    {
        for (int i = 0; i < _enemiesCountInWave; i++)
        {
            int picked = Random.Range(0, _enemyTypeCount + 1);

            for (int j = 0; j < picked + enemyTypeCount; j++)
            {
                if (enemiesPool[j].gameObject.activeInHierarchy == false)
                {
                    enemiesPool[j].transform.position = new Vector2(Random.Range(-4, 4), Random.Range(-7, 7));
                    enemiesPool[j].EnableEnemy();
                    GameManager.instance.currentEnemiesCount += 1;
                    break;
                }
            }
        }
    }

    public void SpawnProjectile(Vector2 _targetPosition, int _damage)
    {
        for (int i = 0; i < projectilesPool.Count; i++)
        {
            if (projectilesPool[i].gameObject.activeInHierarchy)
            {
                projectilesPool[i].gameObject.SetActive(true);
                projectilesPool[i].targetPosition = _targetPosition;
                projectilesPool[i].damage = _damage;
                projectilesPool[i].MoveToTarget();
            }
        }
    }

    public void SpawnHope(Vector2 _enemyPosition, int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            if (hopesPool[i].gameObject.activeInHierarchy)
            {
                hopesPool[i].transform.position = _enemyPosition + (Random.insideUnitCircle * Random.Range(-1, 2));
                hopesPool[i].gameObject.SetActive(true);
            }
        }
    }
}