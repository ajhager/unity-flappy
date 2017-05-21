using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomY : MonoBehaviour {
    private Vector3 lastPosition;

	void Awake ()
	{
        this.lastPosition = this.transform.position;
    }

    void Update () {
        if (this.lastPosition.x <= 10 && this.transform.position.x > 10) {
            this.transform.position = new Vector3(this.transform.position.x, Random.Range(-1f, 1f), this.transform.position.z);
        }

        this.lastPosition = this.transform.position;
    }
}
