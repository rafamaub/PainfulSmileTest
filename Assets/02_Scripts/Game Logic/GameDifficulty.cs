using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty Singleton;

    public float spawnTime;
    public float gameSessionTime;
    private void Awake()
    {
        if(Singleton)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetSpawnTime(float time)
    {
        spawnTime = time;
    }

    public void SetGameSessionTime(float time)
    {
        gameSessionTime = time;
    }
}
