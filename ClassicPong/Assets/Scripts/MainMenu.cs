using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficultyText;
    private bool isEasy = true;
    public void StartGame()
    {
        PlayerPrefs.SetInt("difficulty", isEasy ? 0 : 1);
        SceneManager.LoadScene("Game");
    }

    public void ChangeDifficulty()
    {
        isEasy = !isEasy;
        if(isEasy)
            difficultyText.text = "EASY";
        else
            difficultyText.text = "HARD";
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
