using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Inspector Fields
    [SerializeField] private GameInput input;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSpeedMax = 1f;

    //Private Fields
    private float turnSpeed;

    //Events
    public event EventHandler<OnKillEventArgs> OnKill;
    public class OnKillEventArgs : EventArgs
    {
        public int Points;
    }
    
        private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        turnSpeed = Mathf.Lerp(turnSpeed, 0f, Time.deltaTime * 5);

        if (input.IsGasPressed())
        {
            rb.AddForce(transform.up * speed);
            turnSpeed = turnSpeedMax;
        }

        if (input.IsTurnLeftPressed())
        {
            rb.AddTorque(turnSpeed);
        }

        if (input.IsTurnRightPressed())
        {
            rb.AddTorque(-turnSpeed);
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
            rb.AddForce(-rb.velocity * killable.GetMass(), ForceMode2D.Impulse);

            //Kill
            killable.Perish();
        }
    }

    public float GetSpeed()
    {
        float speedScale = 10f;
        return rb.velocity.magnitude * speedScale;
    }

}
