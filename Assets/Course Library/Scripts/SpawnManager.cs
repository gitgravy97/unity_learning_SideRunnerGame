using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;

    public Vector3 spawnPoint = new Vector3(25, 0, 0);
    public float startDelay = 2;
    public float repeatDelay = 2;

    private PlayerController playerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    void SpawnObstacle() {
        if (playerScript.gameOver == false)
        {
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(randomObstacle, spawnPoint, randomObstacle.transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
