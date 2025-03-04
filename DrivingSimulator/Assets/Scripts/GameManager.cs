using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startGamePanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI winnerText;
    public ScoreHandler scoreHandler;

    private bool[] playersFinished = new bool[2]; // tracking both players
    private int finishedCount = 0; // count for players crossing the finish line

    void Start()
    {
        startGamePanel.SetActive(true); // show start game ui
        gameOverPanel.SetActive(false); // hide game over ui at the start
        Time.timeScale = 0f; // pause game
    }

    public void PlayerFinished(int playerIndex)
    {
        if (!playersFinished[playerIndex]) // ensure each player is counted only once
        {
            playersFinished[playerIndex] = true;
            finishedCount++;

            if (finishedCount == 2) 
            {
                DeclareWinner();
            }
        }
    }

    private void DeclareWinner()
    {
        int player1Hits = scoreHandler.GetPlayerScore(0);
        int player2Hits = scoreHandler.GetPlayerScore(1);

        int winner;
        if (player1Hits < player2Hits)  {
            winner = 0;
        }
        else if (player2Hits < player1Hits) {
            winner = 1;
        }
        else {
            winner = -1; // tie
        }

        if (winner == -1) {
            winnerText.text = "it's a tie ... both players had " + player1Hits + " hits\nplay sad wii mario kart music";
        }
        else {
            winnerText.text = "player " + (winner + 1) + " wins with " + scoreHandler.GetPlayerScore(winner) + " hits!\nother player you suck .. \nbooooos from the crowd";
        }

        gameOverPanel.SetActive(true); // show ui
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // unpause game
        startGamePanel.SetActive(false); // hide start game panel once player clicks button
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // reload game!
    }
}

