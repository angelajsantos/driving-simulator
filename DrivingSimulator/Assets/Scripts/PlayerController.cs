using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // private variables
    private float speed = 18.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    public string inputID;
    public int playerIndex;
    private ScoreHandler scoreHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // getting player input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // move vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // rotate vehicle based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            Debug.Log("you have reached the finish line! :D");
        } 
    }  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            scoreHandler.AddHit(playerIndex);
            Debug.Log("hit detected! player " + playerIndex + " hit an obstacle boooo bad");
        }
    }

}
