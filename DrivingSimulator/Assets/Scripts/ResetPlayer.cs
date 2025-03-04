using UnityEngine;

public class ResetPlayer : MonoBehaviour
{

    public GameObject player;
    public Transform respawnPoint;
    
    public string playerTag = "Player";  // You can set this tag in the Inspector if needed


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the trigger
        if (other.CompareTag(playerTag))
        {
            // Check if the specific player (the one who fell off) should respawn
            if (other.gameObject == player)
            {
                // Reset the player's position to the respawn point
                player.transform.position = respawnPoint.position;
            }
        }
    }
}
