using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    Vector3 startPosition;
    float startTime;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat((Time.time - startTime) * scrollSpeed, tileSize);
        transform.position = startPosition - new Vector3(newPosition, 0, 0);
    }
}