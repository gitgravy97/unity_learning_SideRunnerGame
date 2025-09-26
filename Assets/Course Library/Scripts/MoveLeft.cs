using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (playerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);    
        }
    }
}
