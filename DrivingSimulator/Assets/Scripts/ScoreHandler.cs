using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{

    public TextMeshProUGUI[] countText;
    private int[] playerScores = new int[2]; // array to store scores for both players

    void Start()
    {
        // initialize score display
        UpdateScoreText(0);  
        UpdateScoreText(1);  
    }

    public void AddHit(int playerIndex)
    {
        playerScores[playerIndex]++;  
        UpdateScoreText(playerIndex); 
    }

    // update ui text
    private void UpdateScoreText(int playerIndex)
    {
        countText[playerIndex].text = "hit count: " + playerScores[playerIndex].ToString();
    }

    public int GetPlayerScore(int playerIndex)
    {
        return playerScores[playerIndex];
    }

}
