using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    [SerializeField] private Slider gameSessionSlider;
    [SerializeField] private Slider spawnTimeSlider;

    // Start is called before the first frame update
    void Start()
    {
        LoadDifficulty();
        gameSessionSlider.onValueChanged.AddListener(SaveDifficulty);
        spawnTimeSlider.onValueChanged.AddListener(SaveDifficulty);
    }

    void LoadDifficulty()
    {
        gameSessionSlider.value = GameDifficulty.Singleton.gameSessionTime;
        spawnTimeSlider.value = GameDifficulty.Singleton.spawnTime;
    }

    public void SaveDifficulty(float value)
    {
        GameDifficulty.Singleton.gameSessionTime = gameSessionSlider.value;
        GameDifficulty.Singleton.spawnTime = spawnTimeSlider.value;
    }
}
