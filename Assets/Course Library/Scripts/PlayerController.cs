using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    public float jumpForce = 10;
    public bool isOnGround = true;
    public float gravityModifier;

	public ParticleSystem explosionParticle;
	public ParticleSystem dirtParticle;
	
	private Rigidbody playerBody;
	private Animator playerAnim;
	

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerBody = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
			dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision Enter");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
			dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
			dirtParticle.Stop();

			playerAnim.SetBool("Death_b", true);
			playerAnim.SetInteger("DeathType_int", 1);
			
			explosionParticle.Play();
        }
    }
}
