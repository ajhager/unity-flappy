using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float upwardForce = 250f;

    void Start()
    {
        GameManager game = GameObject.FindObjectOfType<GameManager>();
        game.onActivate += this.Activate;
    }

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.position.y * 5);

        if (Input.GetButtonDown("Fire1"))
        {
            this.rigidbody.velocity = Vector3.zero;
            this.rigidbody.AddForce(Vector3.up * this.upwardForce);
        }
    }

    void Activate()
    {
        this.transform.Find("Tapper").gameObject.SetActive(false);
        this.transform.Find("Smoke").gameObject.SetActive(true);
        GetComponent<Rigidbody2D>().WakeUp();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager game = GameObject.FindObjectOfType<GameManager>();

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