using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody;
    public bool gameOver = false;

    public float jumpForce = 10;
    public bool isOnGround = true;

    public float gravityModifier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision Enter");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
