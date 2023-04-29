using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D carRigidbody2D;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float turnSpeed = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            carRigidbody2D.AddForce(transform.up * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            carRigidbody2D.AddTorque(turnSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            carRigidbody2D.AddTorque(-turnSpeed);
        }



    }
}
