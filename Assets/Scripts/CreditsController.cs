using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private string gameSceneName;

    private void Start()
    {
        returnButton.onClick.AddListener(MainMenu);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
