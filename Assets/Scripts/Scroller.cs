using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition - new Vector3(newPosition, 0, 0);
    }
}
