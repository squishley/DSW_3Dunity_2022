using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private string gameScene;
    [SerializeField] private string creditsScene;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        creditsButton.onClick.AddListener(Credits);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    
    private void Credits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    
}

