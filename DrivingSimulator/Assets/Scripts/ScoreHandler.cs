using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{

    public TextMeshProUGUI[] countText;
    private int[] playerScores = new int[2]; // Array to store scores for both players

    void Start()
    {
        // Initialize score display
        UpdateScoreText(0);  // Player 1
        UpdateScoreText(1);  // Player 2
    }

    // Method to add a hit for a specific player
    public void AddHit(int playerIndex)
    {
        playerScores[playerIndex]++;  // Increment the score for the specified player
        UpdateScoreText(playerIndex); // Update the UI text for that player
    }

    // Method to update the UI text
    private void UpdateScoreText(int playerIndex)
    {
        countText[playerIndex].text = "hit count: " + playerScores[playerIndex].ToString();
    }
}
