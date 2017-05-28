using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upwardForce = 250f;

    new Rigidbody2D rigidbody;

    void Start()
    {
        GameManager game = FindObjectOfType<GameManager>();
        game.OnActivated += Activate;
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.position.y * 5);

        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector3.up * upwardForce);
        }
    }

    void Activate()
    {
        transform.Find("Tapper").gameObject.SetActive(false);
        transform.Find("Smoke").gameObject.SetActive(true);
        GetComponent<Rigidbody2D>().WakeUp();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager game = FindObjectOfType<GameManager>();

        if (other.gameObject.name == "Star")
        {
            Destroy(other.gameObject);
            game.OnScore(1);
        }
        else
        {
            game.OnGameOver();
        }
    }
}