using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void OnActivate();
    public event OnActivate OnActivated;

    bool activated;
    int score;
    Text scoreText;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !activated)
        {
            OnActivated();
            activated = true;
        }
    }

    public void OnScore(int amount)
    {
        score += amount;
        scoreText.text = "" + score;
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene(0);
    }
}