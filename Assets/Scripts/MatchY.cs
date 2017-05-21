using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchY : MonoBehaviour {
    public GameObject pairedObject;

    private Vector3 lastPosition;

	void Awake ()
	{
        this.lastPosition = this.transform.position;
    }

    void Update () {
        if (this.lastPosition.x >= -10 && this.transform.position.x < -10) {
            this.transform.position = new Vector3(this.transform.position.x, this.pairedObject.transform.position.y, this.transform.position.z);
        }

        this.lastPosition = this.transform.position;
    }
}


