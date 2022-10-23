using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    public void PlayGame()
    {
        SceneLoader.Singleton.LoadNewScene(1);
    }

    public void ReturnToMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void OptionsScreen()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
}
