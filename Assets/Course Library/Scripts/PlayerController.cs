using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody;

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
        Debug.Log("Collision");
        isOnGround = true;
    }
}
