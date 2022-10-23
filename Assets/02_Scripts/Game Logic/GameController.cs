using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int points = 0;

    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();

    [Header("HUDS")]
    [SerializeField] private GameplayHud gameplayHud;
    [SerializeField] private GameOverScreen gameOverHud;

    [HideInInspector] public float gameSessionTime;
    float enemySpawnTime;
    // Start is called before the first frame update
    void Awake()
    {
        gameplayHud.controller = this;
        gameOverHud.myGameController = this;
        gameSessionTime = GameDifficulty.Singleton.gameSessionTime;
        enemySpawnTime = GameDifficulty.Singleton.spawnTime;
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, enemySpawnTime);
    }

    private void Update()
    {
        gameSessionTime -= Time.deltaTime;

        if(gameSessionTime <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if(FindObjectOfType<PlayerShipInput>())
            FindObjectOfType<PlayerShipInput>().DisableInput();

        CancelInvoke("SpawnEnemy");

        gameplayHud.gameObject.SetActive(false);
        Invoke("GameOverScreen", 1.5f);
    }

    void GameOverScreen()
    {
        gameOverHud.gameObject.SetActive(true);
    }
    void SpawnEnemy()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject randomEnemy = enemies[Random.Range(0, enemies.Count)];

        Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
    }

    public void EnemyKilled()
    {
        points++;
    }
}
