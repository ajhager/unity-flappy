using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float upwardForce = 250f;

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
}
