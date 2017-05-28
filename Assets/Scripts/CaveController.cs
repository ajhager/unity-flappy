using UnityEngine;

public class CaveController : MonoBehaviour
{
    public GameObject spike;
    public float gap;
    public float scrollSpeed;

    Transform spikes;
    Scroller ground;
    bool activated;
    float timer;

    void Start()
    {
        GameManager game = FindObjectOfType<GameManager>();
        game.OnActivated += Activate;

        spikes = transform.Find("Spikes");
        ground = transform.Find("Ground").GetComponent<Scroller>();
    }

    void Update()
    {
        ground.scrollSpeed = scrollSpeed;

        if (activated)
        {
            timer += Time.deltaTime;

            if (timer > (gap / scrollSpeed))
            {
                Instantiate(spike, new Vector3(11, Random.Range(-1.5f, 1.5f), 0), Quaternion.identity, spikes);
                timer = 0;
            }
        }

        foreach (Transform t in spikes)
        {
            float newX = t.position.x - (scrollSpeed * Time.deltaTime);
            t.position = new Vector3(newX, t.position.y, t.position.z);

            if (t.position.x < -10)
            {
                Destroy(t.gameObject);
            }
        }
    }

    void Activate()
    {
        activated = true;
    }
}