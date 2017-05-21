using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public delegate void OnActivate();
    public event OnActivate onActivate;

    private bool activated = false;

    void Update () {
        if (Input.GetButtonDown("Fire1") && !this.activated)
		{
            this.onActivate();
            this.activated = true;
        }
	}

	public void OnGameOver() {
        SceneManager.LoadScene(0);
    }
}
