using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D carRigidbody2D;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSpeed = 1f;
    private float usedTurnSpeed;

    private void FixedUpdate()
    {

        usedTurnSpeed = Mathf.Lerp(usedTurnSpeed, 0f, Time.deltaTime * 5);

        if (Input.GetKey(KeyCode.W))
        {
            carRigidbody2D.AddForce(transform.up * speed);
            usedTurnSpeed = turnSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            carRigidbody2D.AddTorque(usedTurnSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            carRigidbody2D.AddTorque(-usedTurnSpeed);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Human human = collision.gameObject.GetComponent<Human>();
        if (human != null)
        {
            Debug.Log(human);
            human.Perish();
        }
    }

}
