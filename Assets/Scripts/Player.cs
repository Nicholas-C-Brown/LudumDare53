using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D carRigidbody2D;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSpeedMax = 1f;

    public event EventHandler<OnKillEventArgs> OnKill;
    public class OnKillEventArgs : EventArgs
    {
        public int Points;
    }
    
    private float turnSpeed;

    private void FixedUpdate()
    {

        turnSpeed = Mathf.Lerp(turnSpeed, 0f, Time.deltaTime * 5);

        if (Input.GetKey(KeyCode.W))
        {
            carRigidbody2D.AddForce(transform.up * speed);
            turnSpeed = turnSpeedMax;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        AbstractKillable killable = collision.gameObject.GetComponent<AbstractKillable>();
        if (killable != null)
        {
            //Invoke event
            OnKill?.Invoke(this, new OnKillEventArgs { Points = killable.GetPoints() });

            //Apply stopping force
            carRigidbody2D.AddForce(-carRigidbody2D.velocity * killable.GetMass(), ForceMode2D.Impulse);

            //Kill
            killable.Perish();
        }
    }

}
