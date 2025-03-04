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
    public GameObject confetti;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();

        if (confetti != null)
        {
            confetti.SetActive(false); // hide confetti at the start
        }
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

        // allow car position to reset
        if (inputID == "1" && Input.GetKeyDown(KeyCode.R)) // player 1 presses "R"
        {
            ResetCar();
        }
        else if (inputID == "2" && Input.GetKeyDown(KeyCode.L))  // player 2 presses "T"
        {
            ResetCar();
        }
    }

    public void ResetCar()
    {
        // reset car to upright position
        transform.position += Vector3.up * 2; // avoid ground clipping
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);  // reset rotation
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;  // stop the car's movement
        rb.angularVelocity = Vector3.zero;  // stop the car's rotation
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            if (confetti != null)
            {
                confetti.SetActive(true); // activate confetti effect
            }
            FindObjectOfType<GameManager>().PlayerFinished(playerIndex); 
            Debug.Log("player " + (playerIndex + 1) + " has reached the finish line! :D");
        } 
    }  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            scoreHandler.AddHit(playerIndex);
            Debug.Log("hit detected! player " + (playerIndex + 1) + " hit an obstacle boooo bad");
        }
    }

}
