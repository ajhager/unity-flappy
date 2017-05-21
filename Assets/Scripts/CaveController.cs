using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveController : MonoBehaviour
{
    public GameObject spike;
    public float gap;
    public float scrollSpeed;

    private Transform spikes;
    private Scroller ground;
    private bool activated;
    private float timer;

    void Start ()
    {
        GameManager game = GameObject.FindObjectOfType<GameManager>();
        game.onActivate += this.Activate;

        this.spikes = this.transform.Find("Spikes");
        this.ground = this.transform.Find("Ground").GetComponent<Scroller>();
    }

    void Update ()
    {
        this.ground.scrollSpeed = this.scrollSpeed;

        if (this.activated)
		{
            this.timer += Time.deltaTime;

			if (this.timer > (this.gap / this.scrollSpeed))
			{
                Object.Instantiate(this.spike, new Vector3(11, Random.Range(-1.5f, 1.5f), 0), Quaternion.identity, this.spikes);
                this.timer = 0;
            }
        }

        foreach (Transform t in this.spikes)
        {
            float newX = t.position.x - (this.scrollSpeed * Time.deltaTime);
            t.position = new Vector3(newX, t.position.y, t.position.z);

            if (t.position.x < -10)
            {
                Destroy(t.gameObject);
            }
        }
    }

	void Activate ()
	{
        this.activated = true;
    }
}
