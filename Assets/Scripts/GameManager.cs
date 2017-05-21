using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public delegate void OnActivate();
    public event OnActivate onActivate;

    private bool activated = false;
    private int score = 0;
    private Text scoreText;

    void Awake ()
    {
        this.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && !this.activated)
		{
            this.onActivate();
            this.activated = true;
        }
	}

    public void OnScore (int amount)
    {
        this.score += amount;
        this.scoreText.text = "" + this.score;
    }

	public void OnGameOver ()
    {
        SceneManager.LoadScene(0);
    }
}
