using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverScreen : MonoBehaviour
{
    [HideInInspector] public GameController myGameController;
    [SerializeField] private TextMeshProUGUI pointsText;

    private void OnEnable()
    {
        pointsText.text = myGameController.points.ToString();
    }

    public void PlayAgainBUTTON()
    {
        SceneLoader.Singleton.ReloadScene();
    }

    public void GoToMenu()
    {
        SceneLoader.Singleton.LoadNewScene(0);
    }
}
