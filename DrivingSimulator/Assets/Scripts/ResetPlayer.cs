using UnityEngine;

public class ResetPlayer : MonoBehaviour
{

    public GameObject player;
    public Transform respawnPoint;

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
        // check if the player collides with the trigger
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == player)
            {
                // reset the player's position to the respawn point
                player.transform.position = respawnPoint.position;
            }
        }
    }
}
