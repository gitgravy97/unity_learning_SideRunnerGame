using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private Vector3 startingPosition;

    private float repeatWidth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        startingPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startingPosition.x - repeatWidth)
        {
            transform.position = startingPosition;
        }
    }
}
