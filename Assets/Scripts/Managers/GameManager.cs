using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private const int MAX_ENEMY_PER_WAVE = 10;

    public int hope = 0;
    public int wave = 1;
    public int enemiesPerWave = 5;
    public int enemiesKilled = 0;
    public int currentEnemiesCount = 0;
    public int incrementEnemiesInWave = 2;
    public GameObject player;

    [SerializeField] private float timeBetweenWaves = 2;
    private SpawnManager spawnManager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        spawnManager = GetComponent<SpawnManager>();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Timing.RunCoroutine(InitializeWave());
    }

    private IEnumerator<float> InitializeWave()
    {
        yield return Timing.WaitForSeconds(timeBetweenWaves);

        spawnManager.SpawnWave(enemiesPerWave, wave);
    }


    private void Update()
    {
        if (enemiesKilled >= currentEnemiesCount)
        {
            //TODO: Stop the game and start a new wave;
        }
    }

    private void IncrementWave()
    {
        wave += 1;

        if (wave % 3 == 0 && wave != 0)
            enemiesPerWave += incrementEnemiesInWave;

        GUIManager.instance.UpdateWave();

        spawnManager.SpawnWave(enemiesPerWave, wave);
    }

}