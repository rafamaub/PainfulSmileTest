using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Singleton;
    [SerializeField] private CanvasGroup _canvas;
    [SerializeField] private float durationInSeconds;
    [SerializeField] private float durationInSecondsToFadeOut = 5f;

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReloadScene()
    {
        _FadeIn(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNewScene(string name)
    {
        _FadeIn(name);
    }

    public void LoadNewScene(int number)
    {
        _FadeIn(number);
    }
    public void LoadNewScene(int number, float customTime)
    {
        _FadeIn(number);
    }
    private void _FadeIn(string name)
    {

        _canvas.interactable = true;
        _canvas.blocksRaycasts = true;
        _canvas.alpha = 1f;
        SceneLoad(name);

    }

    private void _FadeIn(int index)
    {
        _canvas.interactable = true;
        _canvas.blocksRaycasts = true;
        _canvas.alpha = 1f;
        SceneLoad(index);
    }

    private void _FadeOut()
    {
        _canvas.alpha = 0f;
        durationInSecondsToFadeOut = durationInSeconds;
        _canvas.interactable = false;
        _canvas.blocksRaycasts = false;
    }

    void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
        _FadeOut();
    }

    void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
        _FadeOut();
    }
}
