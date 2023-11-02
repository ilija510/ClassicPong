using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int MyScore = 0;
    private int AIScore = 0;
    public bool isGameOver = false;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private TextMeshProUGUI endGameText;
    public void playerScored()
    {
        MyScore++;
        updateScore();
        CheckWin();
    }

    public void aiScored()
    {
        AIScore++;
        updateScore();
        CheckWin();
    }

    private void updateScore()
    {
        scoreText.text = MyScore + " - " + AIScore;
    }

    private void CheckWin()
    {
        if (MyScore == 5)
        {
            endGameText.text = "You win!";
            endGameText.color = Color.green;
            endGameScreen.SetActive(true);
            isGameOver = true;
        }
        else if (AIScore == 5)
        {
            endGameText.text = "You lose!";
            endGameText.color = Color.red;
            endGameScreen.SetActive(true);
            isGameOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
