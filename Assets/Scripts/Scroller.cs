using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    private Vector3 startPosition;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat((Time.time - this.startTime) * scrollSpeed, tileSize);
        transform.position = startPosition - new Vector3(newPosition, 0, 0);
    }
}
